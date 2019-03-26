using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TestForMoneyveo
{
    [TestFixture]
    public class TestClass
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver("C:\\chromedriver_win32");
            driver.Url = "http://www.google.com";
        }

        [Test]
        public void Test()
        {
            string searchPhrase = "Selenium IDE export to C#";
            string searchTerm = "Selenium IDE";
            int IndexOfElementToVerify = 3;

            IWebElement search_input = driver.FindElement(By.XPath("//input[@name='q']"));
            search_input.SendKeys(searchPhrase);

            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            IWebElement search_button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='btnK' and @type='submit']")));
            search_button.Click();

            IList<IWebElement> searchResultsList = driver.FindElements(By.XPath("//div[@class='g']"));
            string searchResultText = searchResultsList[IndexOfElementToVerify].Text;
            Assert.IsTrue(searchResultText.ToLower().Contains(searchTerm.ToLower()));
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
