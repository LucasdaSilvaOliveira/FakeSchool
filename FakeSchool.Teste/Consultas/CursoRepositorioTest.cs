using FakeSchool.Domain.Escola;
using FakeSchool.Infra.Repositorios.CursoRepo;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Teste.Consultas
{
    public class CursoRepositorioTest
    {
        [Fact]
        public void ObtendoCursos()
        {
            // Arrange
            var mockCursoRepositorio = new Mock<ICursoRepositorio>();
            var cursoMock = new List<Curso>
            {
                new Curso { Id = 1,Nome = "Análise e Desenvolvimento de Sistemas", DuracaoAnos = 3},
                new Curso { Id = 2,Nome = "Direito", DuracaoAnos = 5},
                new Curso { Id = 3,Nome = "Enfermagem", DuracaoAnos = 4}
            };

            mockCursoRepositorio.Setup(x => x.ObterTodos()).Returns(cursoMock);

            // Act

            var cursos = mockCursoRepositorio.Object.ObterTodos();

            // Assert
            Assert.NotNull(cursos);
        }
    }
}
