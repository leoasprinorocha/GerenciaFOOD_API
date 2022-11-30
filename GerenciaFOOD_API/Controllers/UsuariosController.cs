using GerenciaFood_Domain.Interfaces.Usuarios;
using GerenciaServico.Domain.ViewModels.Usuario;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciaFOOD_API.Controllers
{

    [Route("Usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IAuthenticationService _authenticationService;

        public UsuariosController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            await _authenticationService.Registrar(registerUser);    
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {

            return Ok();
        }
    }
}
