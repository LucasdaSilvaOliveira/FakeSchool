using System.ComponentModel.DataAnnotations;

namespace FakeSchool.Web.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "UserName obrigatório!")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Senha obrigatória!")]
        public string Senha { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
