using CarteiraDigitalAPI.Data;
using CarteiraDigitalAPI.Dtos.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigitalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        /// <summary>
        /// Cadastrar um novo usuário.
        /// </summary>
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UsuarioRegisterDto request)
        {
            var response = await _authRepo.Register(
                new Usuario{ Email = request.Email }, request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Fazer login.
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UsuarioLoginDto request)
        {
            var response = await _authRepo.Login(request.Email, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
