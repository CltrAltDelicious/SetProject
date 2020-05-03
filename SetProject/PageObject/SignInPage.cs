using OpenQA.Selenium;

namespace SetProject.PageObject
{
    public class SignInPage : PageObjectBase
    {
        private static readonly By SignUpButton = By.XPath("//div[@class='no-account']/a");
        
        public SignInPage(IWebDriver driver) : base(driver)
        {
        }
        
        public SignUpPage ClickOnSignUp()
        {
            Driver.FindElement(SignUpButton).Click();
            return new SignUpPage(Driver);
        }

    }
}