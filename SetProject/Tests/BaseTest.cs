using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SetProject.Framework;

namespace SetProject.Tests
{
    public abstract class BaseTest
        {
            protected readonly IWebDriver Driver;

            protected BaseTest()
            {
                Driver = new ChromeDriver();
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().ImplicitWait = Settings.ImplicitWait;
                Driver.Navigate().GoToUrl(Settings.Url);
            }

            [OneTimeTearDown]
            public void OneTimeTearDown() => Driver.Close();
        
        }
}