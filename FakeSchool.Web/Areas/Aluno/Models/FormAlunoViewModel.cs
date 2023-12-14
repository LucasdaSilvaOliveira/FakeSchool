using FakeSchool.Domain.Escola;
using System.ComponentModel.DataAnnotations;

namespace FakeSchool.Web.Areas.Aluno.Models
{
    public class FormAlunoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        public int CursoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int AnoLetivo { get; set; }

    }
}
