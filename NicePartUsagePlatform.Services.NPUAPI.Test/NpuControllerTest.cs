using Microsoft.EntityFrameworkCore;
using Xunit;
using AutoMapper;
using Moq;
using NicePartUsagePlatform.Services.NPUAPI.Controllers;
using NicePartUsagePlatform.Services.NPUAPI.Data;
using NicePartUsagePlatform.Services.NPUAPI.Models.Dto;
using NicePartUsagePlatform.Services.NPUAPI.Models;

namespace NicePartUsagePlatform.Services.NPUAPI.Test
{
    public class NpuControllerTests
    {
        [Fact]
        public void Get_ReturnsAllNpus()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDbForGet")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Npus.AddRange(
                    new Npu { NpuId = 1, ElementName = "TestElement1", Description = "Description1", ImageUrl = "ImageUrl1", UserId = Guid.NewGuid() },
                    new Npu { NpuId = 2, ElementName = "TestElement2", Description = "Description2", ImageUrl = "ImageUrl2", UserId = Guid.NewGuid() }
                );
                context.SaveChanges();
            }

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<IEnumerable<NpuListDto>>(It.IsAny<IEnumerable<Npu>>()))
                      .Returns((IEnumerable<Npu> source) => source.Select(npu => new NpuListDto
                      {
                          NpuId = 1,
                          ElementName = "TestElement1",
                          Description = "Description1",
                          ImageUrl = "ImageUrl1"
                      }));

            // Act & Assert
            using (var context = new AppDbContext(options))
            {
                var controller = new NpuController(context, mockMapper.Object, null);
                var result = controller.Get();

                // Assert
                Assert.NotNull(result);
                var responseDto = Assert.IsType<ResponseDto>(result);
                var resultData = Assert.IsAssignableFrom<IEnumerable<NpuListDto>>(responseDto.Result);
                Assert.Equal(2, resultData.Count());
            }
        }

        [Fact]
        public void GetById_ReturnsNpu()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDbForGetById")
                .Options;

            var npuId = 1;
            using (var context = new AppDbContext(options))
            {
                context.Npus.AddRange(
                    new Npu { NpuId = 1, ElementName = "TestElement1", Description = "Description1", ImageUrl = "ImageUrl1", UserId = Guid.NewGuid() },
                    new Npu { NpuId = 2, ElementName = "TestElement2", Description = "Description2", ImageUrl = "ImageUrl2", UserId = Guid.NewGuid() }
                );
                context.SaveChanges();
            }

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<NpuListDto>(It.IsAny<Npu>()))
                      .Returns((Npu source) => new NpuListDto { ElementName = source.ElementName, Description = source.Description });

            using (var context = new AppDbContext(options))
            {
                var controller = new NpuController(context, mockMapper.Object, null);
                var result = controller.Get(npuId);

                Assert.NotNull(result);
                var response = Assert.IsType<ResponseDto>(result);
                Assert.True(response.IsSuccess);
                var npuDto = Assert.IsType<NpuListDto>(response.Result);
                Assert.Equal("TestElement1", npuDto.ElementName);
            }
        }

        [Fact]
        public void GetById_ReturnsNotFoundMessage_WhenNpuDoesNotExist()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDbForGetByIdNotFound")
                .Options;

            var nonExistentNpuId = 999;
            using (var context = new AppDbContext(options))
            {
            }

            var mockMapper = new Mock<IMapper>();

            using (var context = new AppDbContext(options))
            {
                var controller = new NpuController(context, mockMapper.Object, null);
                var result = controller.Get(nonExistentNpuId);

                Assert.NotNull(result);
                var response = Assert.IsType<ResponseDto>(result);
                Assert.False(response.IsSuccess);
                Assert.Equal("Sequence contains no elements", response.Message);
            }
        }

        [Theory]
        [InlineData("TestElement")]
        [InlineData("Test")]
        public void GetByElement_ReturnsFilteredNpus(string searchElement)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: $"TestDbForGetByElement_{searchElement}")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Npus.AddRange(
                    new Npu { NpuId = 1, ElementName = "TestElement1", Description = "Description1", ImageUrl = "ImageUrl1", UserId = Guid.NewGuid() },
                    new Npu { NpuId = 2, ElementName = "TestElement2", Description = "Description2", ImageUrl = "ImageUrl2", UserId = Guid.NewGuid() },
                    new Npu { NpuId = 3, ElementName = "AnotherElement", Description = "Description3", ImageUrl = "ImageUrl3", UserId = Guid.NewGuid() }
                );
                context.SaveChanges();
            }

            var npuListDtos = new List<NpuListDto> {
                new NpuListDto {
                    NpuId = 1,
                    ElementName = "TestElement1",
                    Description = "Description1",
                    ImageUrl = "ImageUrl1"
                },
                new NpuListDto {
                    NpuId = 2,
                    ElementName = "TestElement2",
                    Description = "Description2",
                    ImageUrl = "ImageUrl2"
                }
            };

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<IEnumerable<NpuListDto>>(It.IsAny<IEnumerable<Npu>>()))
                      .Returns(npuListDtos.AsEnumerable);

            using (var context = new AppDbContext(options))
            {
                var controller = new NpuController(context, mockMapper.Object, null);
                var result = controller.GetByElement(searchElement);

                Assert.NotNull(result);
                Assert.True(result.IsSuccess);
                var resultData = Assert.IsAssignableFrom<IEnumerable<NpuListDto>>(result.Result);
                foreach (var npuDto in resultData)
                {
                    Assert.Contains(searchElement, npuDto.ElementName);
                }
            }
        }
    }
}