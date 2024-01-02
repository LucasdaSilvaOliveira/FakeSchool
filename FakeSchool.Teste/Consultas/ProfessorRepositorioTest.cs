using FakeSchool.Domain.Escola;
using FakeSchool.Infra.Repositorios.ProfessorRepo;
using Moq;

namespace FakeSchool.Teste.Consultas
{
    public class ProfessorRepositorioTest
    {
        Mock<IProfessorRepositorio> _mockProfessorRepositorio;
        public ProfessorRepositorioTest()
        {
            _mockProfessorRepositorio = new Mock<IProfessorRepositorio>();
        }

        [Fact(DisplayName = "Teste que obtém professor por Id")]
        public void TesteObterProfessorPorId()
        {

            var professorMoq = new Professor();

            _mockProfessorRepositorio.Setup(x => x.ObterPorId(1)).Returns(professorMoq);

            var professor = _mockProfessorRepositorio.Object.ObterPorId(1);

            Assert.NotNull(professor);
        }

        [Fact(DisplayName = "Teste que obtém todos os professores")]
        public void TesteObterTodosProfessores()
        {
            var listaProfessoresMoq = new List<Professor>
            {
                new Professor { Id = 1,Nome = "Antonio Carlos"},
                new Professor { Id = 2,Nome = "Ana Ferreira"},
                new Professor { Id = 3,Nome = "Lya Alves"}
            };

            _mockProfessorRepositorio.Setup(x => x.ObterTodos()).Returns(listaProfessoresMoq);

            var listaProfessores = _mockProfessorRepositorio.Object.ObterTodos();

            _mockProfessorRepositorio.Verify(x => x.ObterTodos(), Times.Once);

            Assert.NotNull(listaProfessores);
            Assert.Equal(listaProfessores, listaProfessoresMoq);
        }

        [Fact(DisplayName = "Teste de remoção de professor")]
        public void TesteDeletarProfessor()
        {
            var listaProfessoresMoq = new List<Professor>
            {
                new Professor { Id = 1,Nome = "Antonio Carlos"},
                new Professor { Id = 2,Nome = "Ana Ferreira"},
                new Professor { Id = 3,Nome = "Lya Alves"}
            };

            _mockProfessorRepositorio.Setup(x => x.Deletar(It.IsAny<int>())).Callback<int>(id =>
            {
                var professor = listaProfessoresMoq.FirstOrDefault(x => x.Id == id);

                if (professor != null)
                {
                    listaProfessoresMoq.Remove(professor);
                }
            });

            _mockProfessorRepositorio.Object.Deletar(1);

            Assert.Equal(2, listaProfessoresMoq.Count);
        }

        [Fact(DisplayName = "Teste de atualização de professor")]
        public void TesteAtualizacarProfessor()
        {
            var professorMock = new Professor
            {
                Id = 1,
                Nome = "Antonio Carlos"
            };

            _mockProfessorRepositorio.Setup(x => x.Atualizar(It.IsAny<Professor>()));

            _mockProfessorRepositorio.Object.Atualizar(professorMock);

            _mockProfessorRepositorio.Verify(x => x.Atualizar(professorMock), Times.Once);
        }

        [Fact(DisplayName = "Teste de cadastro de professor")]
        public void TesteCadastroDeProfessor()
        {
            var professorMock = new Professor { Id = 1, Nome = "Antonio Carlos" };

            _mockProfessorRepositorio.Setup(x => x.CadastrarProfessor(professorMock));

            _mockProfessorRepositorio.Object.CadastrarProfessor(professorMock);

            _mockProfessorRepositorio.Verify(x => x.CadastrarProfessor(professorMock), Times.Once);
        }

    }
}