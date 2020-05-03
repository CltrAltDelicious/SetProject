using OpenQA.Selenium;
using System;
using System.Linq;
using OpenQA.Selenium;
using SetProject.Framework;
using OpenQA.Selenium.Interactions;

namespace SetProject.PageObject
{
    public class HomePage : PageObjectBase
    {
        private static readonly By SearchQuery = By.ClassName("ui-autocomplete-input");
        private static readonly By SearchButton = By.XPath("//button[@type ='submit']");


        private static readonly By homePageProduct = By.XPath("//*[@id='content']/section/div/article[1]/div/a/img");
        private static readonly By addToCartButton = By.XPath("/html/body/main/section/div/div/section/div[1]/div[2]/div[2]/div[2]/form/div[2]/div/div[2]/button");
        private static readonly By countOfProductInCart = By.XPath("//*[@id='_desktop_cart']/div/div/a/span[2]");
        private readonly Actions action;

        private static readonly By SignInButton = By.XPath("//a/span[@class='hidden-sm-down']");


        public HomePage(IWebDriver driver) : base(driver)
        {
            action = new Actions(driver);  
        }

        public SearchPage ClickOnSearch()
        {
            Driver.FindElement(SearchButton).Click();
            return new SearchPage(Driver);
        }

        public SignInPage ClickOnSignIn()
        {
            Driver.FindElement(SignInButton).Click();
            return new SignInPage(Driver);
        }
        
        public HomePage SearchFieldInput(string search)
        {
            Driver.FindElement(SearchQuery).Clear();
            Driver.FindElement(SearchQuery).SendKeys(search);
            return new HomePage(Driver);
        }



        public void AddToCartOneProduct()
        {
            Driver.FindElement(homePageProduct).Click();
            Driver.FindElement(addToCartButton).Click();
            action.SendKeys(Keys.Escape);
        }
        public string CountOfProductInCart()
        {
            return Driver.FindElement(countOfProductInCart).Text;
        }
    }
    
}