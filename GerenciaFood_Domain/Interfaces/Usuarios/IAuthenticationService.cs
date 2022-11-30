using GerenciaServico.Domain.ViewModels.Usuario;

namespace GerenciaFood_Domain.Interfaces.Usuarios
{
    public interface IAuthenticationService
    {
        Task<LoginResponseViewModel> Logar(LoginUserViewModel loginUser);

        Task<string> Registrar(RegisterUserViewModel registerUser);
    }
}
