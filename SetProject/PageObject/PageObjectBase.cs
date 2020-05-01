using OpenQA.Selenium;

namespace SetProject.PageObject
{
    public class PageObjectBase
        {
            protected readonly IWebDriver Driver;
            public PageObjectBase(IWebDriver driver)
            {
                Driver = driver;
            }
        
        }
    }
