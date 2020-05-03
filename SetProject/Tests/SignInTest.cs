using NUnit.Framework;
using SetProject.PageObject;

namespace SetProject.Tests
{
    public class SignInTest : BaseTest
    {
        
        [TestCase (true, "email1@gmail.com", "password")]
        [TestCase (false, "_email1@gmail.com", "password")]
        public void Test(bool isPositive, string email, string password)
        {
            HomePage mainPage = new HomePage(Driver);
            SignInPage signInPage = mainPage.ClickOnSignIn().InputLogin(email).InputPassword(password).ClickOnSignIn();
            bool isSignedUp = signInPage.SignedInCheck();
            if (isSignedUp) signInPage.ClickOnSignOut();      
            
            if(isPositive)
                Assert.That(isSignedUp, Is.True,
                    $"Message has sent: {(isSignedUp ? "successfully" : "unsuccessfully")}");
            else
                Assert.That(isSignedUp, Is.False,
                    $"Message has sent: {(isSignedUp ? "successfully" : "unsuccessfully")}");
        }
    }
}