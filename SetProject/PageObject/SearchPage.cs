using System;
using System.Linq;
using OpenQA.Selenium;
using SetProject.Framework;

namespace SetProject.PageObject
{
    public class SearchPage : PageObjectBase
    {
        private static readonly By AlertWarning = By.XPath("//div[@id='js-product-list']//section[@id='content']");

        public SearchPage(IWebDriver driver) : base(driver)
        {
        }
        
        public bool IsFound()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            bool isFound = Wait.WaitFor(() =>Driver.FindElements(AlertWarning).Any());
            Driver.Manage().Timeouts().ImplicitWait = Settings.ImplicitWait;

            return !isFound;
        }
    }
}