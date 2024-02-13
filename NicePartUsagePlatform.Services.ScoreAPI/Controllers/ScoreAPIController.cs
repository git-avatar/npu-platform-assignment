using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NicePartUsagePlatform.Services.ScoreAPI.Data;
using NicePartUsagePlatform.Services.ScoreAPI.Models;
using NicePartUsagePlatform.Services.ScoreAPI.Models.Dto;

namespace NicePartUsagePlatform.Services.ScoreAPI.Controllers
{
    [Route("api/score")]
    [ApiController]
    public class ScoreAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public ScoreAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,FAN")]
        public object Get()
        {
            try
            {
                IEnumerable<Score> objList = _db.Scores.ToList();
                _response.Result = _mapper.Map<IEnumerable<ScoreDto>>(objList); 
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
        [Authorize(Roles = "ADMIN,FAN")]
        public object Get(int id)
        {
            try
            {
                Score obj = _db.Scores.First(u => u.ScoreId == id);
                _response.Result = _mapper.Map<ScoreDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByNpu/{npuId:int}")]
        [Authorize(Roles = "ADMIN,FAN")]
        public ResponseDto GetByNpu(int npuId)
        {
            try
            {
                var scoresForNpu = _db.Scores.Where(s => s.NpuId == npuId).ToList();

                if (scoresForNpu.Count == 0)
                {
                    _response.IsSuccess = false;
                    _response.Message = "No score found for the specified NPU.";
                    return _response;
                }

                double averageCreativity = scoresForNpu.Average(s => s.Creativity);
                double averageUniqueness = scoresForNpu.Average(s => s.Uniqueness);

                var responseDto = new
                {
                    AverageCreativity = averageCreativity,
                    AverageUniqueness = averageUniqueness
                };

                _response.Result = responseDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,FAN")]
        public ResponseDto Post([FromBody] ScoreDto scoreDto) 
        {
            try
            {
                Score obj = _mapper.Map<Score>(scoreDto);
                _db.Scores.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ScoreDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] ScoreDto scoreDto)
        {
            try
            {
                Score obj = _mapper.Map<Score>(scoreDto);
                _db.Scores.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ScoreDto>(obj);
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
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Score obj = _db.Scores.First(u => u.ScoreId == id);
                _db.Scores.Remove(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ScoreDto>(obj);
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
