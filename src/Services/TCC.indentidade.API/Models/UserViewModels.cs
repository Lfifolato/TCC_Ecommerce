using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.indentidade.API.Models
{
    public class UserViewModels
    {
        #region Model de Registro de Usuario
        public class UsuarioRegistro
        {
            [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
            [EmailAddress(ErrorMessage = "O Campo {0} está em Formato Inválido")]
            public string Email { get; set; }

            [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
            [StringLength(100, ErrorMessage = "O campo {0} Precisa ter entre {2} e {1} Caracteres", MinimumLength = 6)]
            public string Senha { get; set; }

            [Compare("Senha", ErrorMessage = "As senhas Não Conferem")]
            public string SenhaCofirmada { get; set; }
        }
        #endregion

        #region Model de Login De Usuario
        public class UsuarioLogin
        {

            [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
            [EmailAddress(ErrorMessage = "O Campo {0} está em Formato Inválido")]
            public string Email { get; set; }

            [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
            [StringLength(100, ErrorMessage = "O campo {0} Precisa ter entre {2} e {1} Caracteres", MinimumLength = 6)]
            public string Senha { get; set; }

        }
        #endregion

        #region Models de Configuração de JTW
        public class UsuarioRespostaLogin
        {
            public string AccessToken { get; set; }

            public double ExpiresIn { get; set; }

            public UsuarioToken UsuarioToken { get; set; }
        }

        public class UsuarioToken
        {
            public string Id { get; set; }

            public string Email { get; set; }


            public IEnumerable<UsuarioClaim> Claims { get; set; }
        }

        public class UsuarioClaim
        {
            public string Value { get; set; }

            public string Type { get; set; }
        }
        #endregion

    }
}
