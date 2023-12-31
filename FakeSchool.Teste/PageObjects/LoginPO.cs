using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Teste.PageObjects
{
    public class LoginPO
    {
        private IWebDriver _driver;
        private By inputUsername;
        private By inputSenha;
        private By btnLogin;

        public LoginPO(IWebDriver driver)
        {
            _driver = driver;
            inputUsername = By.Id("UserName");
            inputSenha = By.Id("Senha");
            btnLogin = By.ClassName("btn-primary");
        }

        public void Navegar()
        {
            _driver.Navigate().GoToUrl("https://localhost:44304/");
        }
    }
}
