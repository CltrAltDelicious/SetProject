using OpenQA.Selenium;

namespace SetProject.PageObject
{
    public class HomePage : PageObjectBase
    {
        private static readonly By SearchQuery = By.ClassName("ui-autocomplete-input");
        private static readonly By SearchButton = By.XPath("//button[@type ='submit']");
    
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public SearchPage ClickOnSearch()
        {
            Driver.FindElement(SearchButton).Click();
            return new SearchPage(Driver);
        }

        public HomePage SearchFieldInput(string search)
        {
            Driver.FindElement(SearchQuery).Clear();
            Driver.FindElement(SearchQuery).SendKeys(search);
            return new HomePage(Driver);
        }
    }
    
}