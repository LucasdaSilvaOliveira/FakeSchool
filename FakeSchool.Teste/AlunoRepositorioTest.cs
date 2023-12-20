using FakeSchool.Domain.Escola;
using FakeSchool.Infra.Data;
using FakeSchool.Infra.Repositorios.AlunoRepo;
using FakeSchool.Infra.Repositorios.CursoRepo;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Teste
{
    public class AlunoRepositorioTest
    {

        [Fact]
        public void ObtendoTodosAlunos()
        {
            //Arrange

            var mockAlunoRepositorio = new Mock<IAlunoRepositorio>();
            var listaAluno = new List<Aluno>
            {
                new Aluno { Id = 1,AnoLetivo = 3,CursoId = 3, Nome = "Lucas", Status = "Cursando"},
                new Aluno { Id = 2,AnoLetivo = 2,CursoId = 2, Nome = "Agatha", Status = "Cursando"},
                new Aluno { Id = 3,AnoLetivo = 4,CursoId = 3, Nome = "Luck", Status = "Cursando"}
            };

            mockAlunoRepositorio.Setup(x => x.ObterTodos()).Returns(listaAluno);

            //Act
            var alunos = mockAlunoRepositorio.Object.ObterTodos();

            //Assert
            Assert.NotNull(alunos);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ObtendoAlunosComVariosIds(int id)
        {
            //Arrange

            var mockAlunoRepositorio = new Mock<IAlunoRepositorio>();

            var alunoMock = new Aluno
            { 
                Id = id,
                AnoLetivo = 3,
                CursoId = 1,
                Nome = "Lucas",
                Status = "Cursando"
            };

            mockAlunoRepositorio.Setup(x => x.ObterPorId(id)).Returns(alunoMock);

            //Act
            var aluno = mockAlunoRepositorio.Object.ObterPorId(id);

            //Assert
            Assert.NotNull(aluno);

        }

        [Fact(DisplayName = "Removendo Aluno")]
        public void DeletandoAluno()
        {
            // Arrange
            var mockAlunoRepositorio = new Mock<IAlunoRepositorio>();
            var listaAluno = new List<Aluno>
            {
                new Aluno { Id = 1,AnoLetivo = 3,CursoId = 3, Nome = "Lucas", Status = "Cursando"},
                new Aluno { Id = 2,AnoLetivo = 2,CursoId = 2, Nome = "Agatha", Status = "Cursando"},
                new Aluno { Id = 3,AnoLetivo = 4,CursoId = 3, Nome = "Luck", Status = "Cursando"}
            };

            mockAlunoRepositorio.Setup(x => x.Deletar(It.IsAny<int>())).Callback<int>(id =>
            {
                var aluno = listaAluno.FirstOrDefault(a => a.Id == id);
                if (aluno != null)
                {
                    listaAluno.Remove(aluno);
                }
            });

            // Act
            mockAlunoRepositorio.Object.Deletar(1);

            // Assert
            Assert.Equal(2, listaAluno.Count);
        }

        [Fact]
        public void AtualizandoAluno()
        {
            // Arrange
            var mockAlunoRepositorio = new Mock<IAlunoRepositorio>();

            var alunoMock = new Aluno
            {
                Id = 1,
                AnoLetivo = 3,
                CursoId = 1,
                Nome = "Lucas",
                Status = "Cursando"
            };

            alunoMock.Nome = "Luck";

            mockAlunoRepositorio.Setup(x => x.Atualizar(alunoMock));

            // Act
            mockAlunoRepositorio.Object.Atualizar(alunoMock);

            //Assert
            mockAlunoRepositorio.Verify(x => x.Atualizar(alunoMock), Times.Once);
            Assert.Contains("Luck", alunoMock.Nome);
        }
    }
}