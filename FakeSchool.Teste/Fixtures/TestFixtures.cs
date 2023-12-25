using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Teste.Fixtures
{
    public class TestFixtures : IDisposable
    {
        public IWebDriver driver{ get; set; }

        public TestFixtures(IWebDriver _driver)
        {
            driver = _driver;
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
