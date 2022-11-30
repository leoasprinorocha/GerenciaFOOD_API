using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciaServico.Domain.ViewModels.Usuario
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} esta em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(25, ErrorMessage = "O campo {0} esta em formato inválido")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }
       


    }
}
