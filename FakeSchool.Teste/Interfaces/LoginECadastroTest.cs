using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Teste.Interfaces
{
    public class LoginECadastroTest : IDisposable
    {
        private ChromeDriver _driver;

        public LoginECadastroTest()
        {
            _driver = new ChromeDriver();
        }
        public void Dispose()
        {
            _driver.Quit();
        }

        [Fact]
        public void FazendoLoginComSucesso()
        {

            _driver.Navigate().GoToUrl("https://localhost:44304/");

            var btnLogin = _driver.FindElement(By.ClassName("btn-primary"));
            var inputUserName = _driver.FindElement(By.Id("UserName"));
            var inputSenha = _driver.FindElement(By.Id("Senha"));

            inputUserName.SendKeys("teste");
            inputSenha.SendKeys("Senha123@");

            btnLogin.Click();

            Assert.Contains("Página principal", _driver.Title);
        }
    }
}
