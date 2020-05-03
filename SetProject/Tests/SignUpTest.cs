using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using SetProject.PageObject;

namespace SetProject.Tests
{
    [TestFixture]
    public class SignUpTest : BaseTest
    {
        
        //[TestCase (true, "Ihor", "Kordoba", "email@gmail.com", "password", "10/10/2010")]
        [TestCase (false, "Ihor", "Kordoba", "email@gmail.com", "password", "10/10/2010")]
        public void Test(bool isPositive, string firstName, string lastName, string email, string password, string birthdate)
        {
            HomePage mainPage = new HomePage(Driver);
            SignInPage signInPage = mainPage.ClickOnSignIn();
            SignUpPage signUpPage = signInPage.ClickOnSignUp().InputFirstName(firstName).InputLastName(lastName)
                .InputEmail(email).InputPassword(password).InputBirthdate(birthdate).InputCheckBox().ClickOnSave();
            bool isSignedUp = signUpPage.SignedUpCheck();
                
                if(isPositive)
                Assert.That(isSignedUp, Is.True,
                    $"Message has sent: {(isSignedUp ? "successfully" : "unsuccessfully")}");
            else
                Assert.That(isSignedUp, Is.False,
            $"Message has sent: {(isSignedUp ? "successfully" : "unsuccessfully")}");
        }
    }
}