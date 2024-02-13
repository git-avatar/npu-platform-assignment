using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using NicePartUsagePlatform.Services.NPUAPI.Data;
using NicePartUsagePlatform.Services.NPUAPI.Models;
using NicePartUsagePlatform.Services.NPUAPI.Models.Dto;

namespace NicePartUsagePlatform.Services.NPUAPI.Controllers
{
    [Route("api/npu")]
    [ApiController]
    public class NpuController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        private BlobServiceClient _blobServiceClient;
        private const string containerName = "pencik";

        public NpuController(AppDbContext db, IMapper mapper, BlobServiceClient blobServiceClient)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
            _blobServiceClient = blobServiceClient;
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<Npu> objList = _db.Npus.ToList();
                _response.Result = _mapper.Map<IEnumerable<NpuListDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                Npu obj = _db.Npus.FirstOrDefault(x => x.NpuId == id);
                if(obj != null) 
                {
                    _response.Result = _mapper.Map<NpuListDto>(obj);
                }
                else
                {
                    _response.Message = "The NPU with the given ID cannot be found!";
                }
                
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("search/{element}")]
        public ResponseDto GetByElement(string element)
        {
            try
            {
                IEnumerable<Npu> objList = _db.Npus.Where(x => x.ElementName.Contains(element)).ToList();
                _response.Result = _mapper.Map<IEnumerable<NpuListDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromForm] NpuDto model)
        {
            if (model.File == null || model.File.Length == 0)
            {
                _response.IsSuccess = false;
                _response.Message = "No file uploaded.";
                return _response;
            }
            try
            {
                var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);

                var blobClient = blobContainerClient.GetBlobClient(model.File.FileName);

                using (var stream = model.File.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, true);
                }

                var blobUrl = blobClient.Uri.AbsoluteUri;

                Npu obj = new Npu()
                {
                    Description = model.Description,
                    UserId = new Guid("0af5586a-476d-479e-8aa5-3e6648357057"),
                    ElementName = model.ElementName,
                    ImageUrl = blobUrl,
                    CreatedDate = DateTime.Now,
                };

                _db.Npus.Add(obj);
                _db.SaveChanges();

                _response.Message = blobUrl;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut("{id}")]
        public ResponseDto Put(int id, [FromBody] EditNpuDto editNpuDto)
        {
            try
            {
                Npu existingNpu = _db.Npus.FirstOrDefault(x => x.NpuId == id);

                if (existingNpu != null) {
                    existingNpu.Description = editNpuDto.Description;
                    existingNpu.ElementName = editNpuDto.ElementName;
                }

                _db.SaveChanges();

                _response.Result = _mapper.Map<NpuDto>(existingNpu);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                Npu obj = _db.Npus.FirstOrDefault(x => x.NpuId == id);

                BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);

                string fileName = obj.ImageUrl.Replace("https://testexam20241998.blob.core.windows.net/pencik/", "");

                var blobClient = blobContainerClient.GetBlobClient(fileName);

                await blobClient.DeleteAsync();

                _db.Npus.Remove(obj);
                _db.SaveChanges();

                _response.Message = "NPU is deleted succesfully.";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
