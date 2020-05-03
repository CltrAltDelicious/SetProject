using System;
using System.Linq;
using OpenQA.Selenium;
using SetProject.Framework;


namespace SetProject.PageObject
{
    public class SignUpPage : PageObjectBase
    {
        private static readonly By FirstName = By.XPath("//input[@name='firstname']");
        private static readonly By LastName = By.XPath("//input[@name='lastname']");
        private static readonly By Email = By.XPath("//input[@name='email']");
        private static readonly By Password = By.XPath("//input[@name='password']");
        private static readonly By Birthdate = By.XPath("//input[@name='birthday']");
        private static readonly By CheckBox = By.XPath("//input[@name='psgdpr']");
        private static readonly By SaveButton =
            By.XPath("//button[@class='btn btn-primary form-control-submit float-xs-right']");

        private static readonly By SignOut = By.XPath("//a[@class='account']");
        
        
        public SignUpPage(IWebDriver driver) : base(driver)
        {
        }

        public SignUpPage InputFirstName(string name)
        {
            Driver.FindElement(FirstName).Clear();
            Driver.FindElement(FirstName).SendKeys(name);
            return new SignUpPage(Driver);
        }
        
        public SignUpPage InputLastName(string name)
        {
            Driver.FindElement(LastName).Clear();
            Driver.FindElement(LastName).SendKeys(name);
            return new SignUpPage(Driver);
        }
        
        public SignUpPage InputEmail(string email)
        {
            Driver.FindElement(Email).Clear();
            Driver.FindElement(Email).SendKeys(email);
            return new SignUpPage(Driver);
        }
        
        public SignUpPage InputPassword(string password)
        {
            Driver.FindElement(Password).Clear();
            Driver.FindElement(Password).SendKeys(password);
            return new SignUpPage(Driver);
        }
        
        public SignUpPage InputBirthdate(string birthdate)
        {
            Driver.FindElement(Birthdate).Clear();
            Driver.FindElement(Birthdate).SendKeys(birthdate);
            return new SignUpPage(Driver);
        }
        
        public SignUpPage InputCheckBox()
        {
            Driver.FindElement(CheckBox).SendKeys(Keys.Space);
            return new SignUpPage(Driver);
        }

        public SignUpPage ClickOnSave()
        {
            Driver.FindElement(SaveButton).Click();
            return new SignUpPage(Driver);
        }
        
        public bool SignedUpCheck()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            bool isFound = Wait.WaitFor(() =>Driver.FindElements(SignOut).Any());
            Driver.Manage().Timeouts().ImplicitWait = Settings.ImplicitWait;

            return isFound;
        }
    }

}