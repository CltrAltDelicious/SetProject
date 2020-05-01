using NUnit.Framework;
using SetProject.PageObject;

namespace SetProject.Tests
{
    [TestFixture]
    public class SearchValidationTest : BaseTest
    {
        [TestCase(true, "Printed")]
        [TestCase(false, "Pfrunted")]
        public void Test(bool isPositive, string search)
        {
            HomePage mainPage = new HomePage(Driver);
            SearchPage searchPage = mainPage.SearchFieldInput(search).ClickOnSearch();
            bool isFound = searchPage.IsFound();
            
            if(isPositive)
                Assert.That(isFound, Is.True,
                    $"Message has sent: {(isFound ? "successfully" : "unsuccessfully")}");
            else
                Assert.That(isFound, Is.False,
                    $"Message has sent: {(isFound ? "successfully" : "unsuccessfully")}");
        }
    }
}