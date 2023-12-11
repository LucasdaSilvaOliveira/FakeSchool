using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Domain.Escola
{
	public class Materia
	{
		[Key]
		public virtual int Id { get; set; }

		public virtual string Nome { get; set; }
	}
}
