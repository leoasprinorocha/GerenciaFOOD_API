using GerenciaFood_Domain.Interfaces.Usuarios;
using GerenciaServico.Domain.ViewModels.Usuario;
using System.Configuration;
using System.Net.Http.Headers;

namespace GerenciaFood_Services.Services.Usuarios
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _urlApiAuthentication;

        public AuthenticationService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _urlApiAuthentication = ConfigurationManager.AppSettings["urlApi"];

        }
            
        public async Task<LoginResponseViewModel> Logar(LoginUserViewModel loginUser)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Registrar(RegisterUserViewModel registerUser)
        {
            throw new NotImplementedException();
        }
    }
}
