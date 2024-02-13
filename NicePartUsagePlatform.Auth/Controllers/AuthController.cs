using Microsoft.AspNetCore.Mvc;
using NicePartUsagePlatform.Auth.Models.Dto;
using NicePartUsagePlatform.Auth.Service.IService;

namespace NicePartUsagePlatform.Auth.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _response;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            _response = new();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registerDto)
        {
            var errorMessage = await _authService.Register(registerDto);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            var loginResponse = await _authService.Login(loginDto);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect!";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignedRole = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignedRole)
            {
                _response.IsSuccess = false;
                _response.Message = "Error while assigning role!";
                return BadRequest(_response);
            }
            _response.Result = assignedRole;
            return Ok(_response);
        }
    }
}
