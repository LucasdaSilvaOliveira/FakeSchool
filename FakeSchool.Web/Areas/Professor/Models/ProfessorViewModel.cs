using System.ComponentModel.DataAnnotations;

namespace FakeSchool.Web.Areas.Professor.Models
{
    public class ProfessorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório.")]
        public string Nome { get; set; }
    }
}
