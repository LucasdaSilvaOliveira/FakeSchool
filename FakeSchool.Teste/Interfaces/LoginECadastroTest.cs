﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Teste.Interfaces
{
    public class LoginECadastroTest
    {
        [Fact]
        public void FazendoLoginComSucesso()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44304/");

            var btnLogin = driver.FindElement(By.ClassName("btn-primary"));
            var inputUserName = driver.FindElement(By.Id("UserName"));
            var inputSenha = driver.FindElement(By.Id("Senha"));

            inputUserName.SendKeys("teste");
            inputSenha.SendKeys("Senha123@");

            btnLogin.Click();

            Assert.Contains("Página principal", driver.Title);
        }
    }
}