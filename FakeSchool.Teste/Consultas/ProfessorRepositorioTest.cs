using FakeSchool.Domain.Escola;
using FakeSchool.Infra.Repositorios.CursoRepo;
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

        [Fact(DisplayName = "Teste que obtém todos os professores")]
        public void TestaObterTodosProfessores()
        {
            var mockProfessorRepositorio = new Mock<IProfessorRepositorio>();

            var listaProfessoresMoq = new List<Professor>
            {
                new Professor { Id = 1,Nome = "Antonio Carlos"},
                new Professor { Id = 2,Nome = "Ana Ferreira"},
                new Professor { Id = 3,Nome = "Lya Alves"}
            };

            mockProfessorRepositorio.Setup(x => x.ObterTodos()).Returns(listaProfessoresMoq);

            var listaProfessores = mockProfessorRepositorio.Object.ObterTodos();

            mockProfessorRepositorio.Verify(x => x.ObterTodos(), Times.Once);

            Assert.NotNull(listaProfessores);
            Assert.Equal(listaProfessores, listaProfessoresMoq);
        }

        [Fact(DisplayName = "Teste de remoção de professor")]
        public void TesteDeletarProfessor()
        {
            var mockProfessorRepositorio = new Mock<IProfessorRepositorio>();

            var listaProfessoresMoq = new List<Professor>
            {
                new Professor { Id = 1,Nome = "Antonio Carlos"},
                new Professor { Id = 2,Nome = "Ana Ferreira"},
                new Professor { Id = 3,Nome = "Lya Alves"}
            };

            mockProfessorRepositorio.Setup(x => x.Deletar(It.IsAny<int>())).Callback<int>(id =>
            {
                var professor = listaProfessoresMoq.FirstOrDefault(x => x.Id == id);

                if (professor != null)
                {
                    listaProfessoresMoq.Remove(professor);
                }
            });

            mockProfessorRepositorio.Object.Deletar(1);

            Assert.Equal(2, listaProfessoresMoq.Count);
        }
    }
}