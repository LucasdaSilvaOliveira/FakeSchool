using FakeSchool.Domain.Escola;
using FakeSchool.Infra.Repositorios.ProfessorRepo;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Teste.Consultas
{
    public class ProfessorRepositorioTest
    {
        [Fact]
        public void TestaObterProfessorPorId()
        {
            var mockProfessorRepositorio = new Mock<IProfessorRepositorio>();

            var professorMoq = new Professor();

            mockProfessorRepositorio.Setup(x => x.ObterPorId(1)).Returns(professorMoq);

            var professor = mockProfessorRepositorio.Object.ObterPorId(1);

            Assert.NotNull(professor);
        }
    }
}