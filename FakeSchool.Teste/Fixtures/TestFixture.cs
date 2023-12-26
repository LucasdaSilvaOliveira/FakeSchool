using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Teste.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver driver{ get; set; }

        public TestFixture()
        {
            driver = new ChromeDriver();
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
