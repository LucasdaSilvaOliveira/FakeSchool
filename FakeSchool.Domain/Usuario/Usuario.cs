using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Domain.Usuario
{
	public class Usuario : IdentityUser
	{
		public Usuario() : base()
		{

		}

		public virtual DateTime DataCriacao { get; set; }
	}
}
