using FakeSchool.Teste.Fixtures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Teste.Interfaces
{
    [Collection("Chrome Driver")]
    public class TelaPrincipalTest
    {
        private IWebDriver _driver;
        public TelaPrincipalTest(TestFixture fixture)
        {
            _driver = fixture.driver;
        }

        [Fact]
        public void NavegandoParaTelaDeCursos()
        {
            _driver.Navigate().GoToUrl("https://localhost:44304/");
            var btnLogin = _driver.FindElement(By.ClassName("btn-primary"));
            var inputUserName = _driver.FindElement(By.Id("UserName"));
            var inputSenha = _driver.FindElement(By.Id("Senha"));

            inputUserName.SendKeys("teste");
            inputSenha.SendKeys("Senha123@");

            btnLogin.Click();

            var btnCurso = _driver.FindElement(By.Id("btn-cursos"));

            btnCurso.Click();
            Assert.Contains("Cursos", _driver.Title);
        }
    }
}
