using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Domain.Escola
{
	public class Nota
	{
		[Key]
		public virtual int Id { get; set; }

		public virtual int AlunoId { get; set; }

		[ForeignKey("AlunoId")]
		public virtual Aluno Aluno { get; set; }

		public virtual int MateriaId { get; set; }

		[ForeignKey("MateriaId")]
		public virtual Materia Materia { get; set; }

		public virtual decimal NotaMateria { get; set; }
	}
}
