using FakeSchool.Infra.Data;
using FakeSchool.Infra.Repositorios.AlunoRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Teste.Integração
{
    public class AlunoIntegracaoTest
    {
        [Fact(DisplayName = "Testando integração do repositório aluno")]
        public void TesteDeIntegracaoDoRepositorioDeAluno()
        {
            var options = new DbContextOptionsBuilder<BancoContext>()
                .UseInMemoryDatabase(databaseName: "FakeSchool").Options;

            using (var context = new BancoContext(options))
            {
                context.Alunos.Add(
                 new Domain.Escola.Aluno
                 {
                     Id = 1,
                     CursoId = 1,
                     AnoLetivo = 1,
                     Nome = "Luck Silva",
                     Status = "Cursando",
                     Curso = new Domain.Escola.Curso { Id = 1, Nome = "Tal", DuracaoAnos = 1 }
                 });
                context.Alunos.Add(
                    new Domain.Escola.Aluno
                    {
                        Id = 2,
                        CursoId = 2,
                        AnoLetivo = 2,
                        Nome = "Luizu Craveiro",
                        Status = "Formada",
                        Curso = new Domain.Escola.Curso { Id = 2, Nome = "Tal", DuracaoAnos = 1 }
                    });
                context.Alunos.Add(
                    new Domain.Escola.Aluno
                    {
                        Id = 3,
                        CursoId = 3,
                        AnoLetivo = 3,
                        Nome = "Alex Rodrigues",
                        Status = "Cursando",
                        Curso = new Domain.Escola.Curso { Id = 3, Nome = "Tal", DuracaoAnos = 1 }
                    });
                context.SaveChanges();

                var alunoRepositorio = new AlunoRepositorio(context);

                var users = alunoRepositorio.ObterTodos();

                Assert.NotNull(users);
                Assert.Equal(3, users.Count);
                Assert.Equal("Luck Silva", users.FirstOrDefault(x => x.Id == 1).Nome);
            }
        }
    }
}
