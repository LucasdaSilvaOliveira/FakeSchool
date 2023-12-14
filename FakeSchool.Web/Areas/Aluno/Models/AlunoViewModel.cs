using FakeSchool.Domain.Escola;
using System.ComponentModel.DataAnnotations;

namespace FakeSchool.Web.Areas.Aluno.Models
{
    public class AlunoViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Status { get; set; }

        public int AnoLetivo { get; set; }

        public string Curso { get; set; }

    }
}
