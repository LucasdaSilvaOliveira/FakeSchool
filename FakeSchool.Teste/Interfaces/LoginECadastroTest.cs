using FakeSchool.Teste.Fixtures;
using FakeSchool.Teste.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Teste.Interfaces
{
    [Collection("Chrome Driver")]
    public class LoginECadastroTest
    {
        private IWebDriver _driver;

        public LoginECadastroTest(TestFixture fixtures)
        {
            _driver = fixtures.driver;
        }
    
        [Fact]
        public void FazendoLoginComSucesso()
        {

            var loginPO = new LoginPO(_driver);
            loginPO.Navegar();

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
