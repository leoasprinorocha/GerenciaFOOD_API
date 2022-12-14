using GerenciaFood_Domain.Interfaces.Usuarios;
using GerenciaFood_Services.Helpers;
using GerenciaServico.Domain.ViewModels.Usuario;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Configuration;
using System.Net.Http.Headers;

namespace GerenciaFood_Services.Services.Usuarios
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly UrlsApis _urlsApis;

        public AuthenticationService(IOptions<UrlsApis> urlsApis)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _urlsApis = urlsApis.Value;

        }
            
        public async Task<LoginResponseViewModel> Logar(LoginUserViewModel loginUser)
        {
                
            string urlAction = $"{_urlsApis.apiAuthentication}/authentication/login";
            var result = _httpClient.PostAsync(urlAction, HttpHelpers.GetHttpContent(loginUser)).Result;
            return HttpHelpers.Deserialize<LoginResponseViewModel>(result).Result;
        }

        public async Task<string> Registrar(RegisterUserViewModel registerUser)
        {
            string urlAction = $"{_urlsApis.apiAuthentication}/authentication/register";
            var result = _httpClient.PostAsync(urlAction, HttpHelpers.GetHttpContent(registerUser)).Result;
            return HttpHelpers.Deserialize<string>(result).Result;
        }
    }
}
