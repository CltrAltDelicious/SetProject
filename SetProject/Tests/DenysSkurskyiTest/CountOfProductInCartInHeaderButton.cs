using NUnit.Framework;
using SetProject.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SetProject.Framework;

namespace SetProject.Tests.DenysSkurskyiTest
{
    [TestFixture]
    public class CountOfProductInCartInHeaderButton : BaseTest
    {
        [Test]
        public void countOfProductInCartInHeaderButton()
        {
            HomePage homePage = new HomePage(Driver);

            homePage.AddToCartOneProduct();
            Assert.That(homePage.CountOfProductInCart, Is.EqualTo("(1)"));
        }
    }
}

