using System.ComponentModel.DataAnnotations;

namespace FakeSchool.Web.Areas.Curso.Models
{
    public class FormCursoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int DuracaoAnos { get; set; }
    }
}
