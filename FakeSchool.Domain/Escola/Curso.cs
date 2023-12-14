using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Domain.Escola
{
    public class Curso
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual int DuracaoAnos { get; set; }
    }
}
