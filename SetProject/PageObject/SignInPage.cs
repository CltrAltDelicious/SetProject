using System;
using System.Linq;
using OpenQA.Selenium;
using SetProject.Framework;

namespace SetProject.PageObject
{
    public class SignInPage : PageObjectBase
    {
        private static readonly By SignUpButton = By.XPath("//div[@class='no-account']/a");
        private static readonly By Login = By.XPath("//div[@class='col-md-6']//input[@name='email']");
        private static readonly By Password = By.XPath("//input[@name='password']");
        private static readonly By SignOut = By.XPath("//a[@class='account']");
        private static readonly By SignInButton = By.XPath("//button[@id='submit-login']");
        private static readonly By SignOutButton = By.XPath("//a[@class='logout hidden-sm-down']");
        
        public SignInPage(IWebDriver driver) : base(driver)
        {
        }

        public SignUpPage ClickOnSignUp()
        {
            Driver.FindElement(SignUpButton).Click();
            return new SignUpPage(Driver);
        }

        public SignInPage InputLogin(string login)
        {
            Driver.FindElement(Login).Clear();
            Driver.FindElement(Login).SendKeys(login);
            return new SignInPage(Driver);
        }

        public SignInPage InputPassword(string password)
        {
            Driver.FindElement(Password).Clear();
            Driver.FindElement(Password).SendKeys(password);
            return new SignInPage(Driver);
        }

        public SignInPage ClickOnSignIn()
        {
            Driver.FindElement(SignInButton).Click();
            return new SignInPage(Driver);
        }

        public SignInPage ClickOnSignOut()
        {
            Driver.FindElement(SignOutButton).Click();
            return new SignInPage(Driver);
        }
        
        public bool SignedInCheck()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            bool isFound = Wait.WaitFor(() =>Driver.FindElements(SignOut).Any());
            Driver.Manage().Timeouts().ImplicitWait = Settings.ImplicitWait;
            
            return isFound;
        }
    }
    
}