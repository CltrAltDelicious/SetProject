using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using SetProject.PageObject;

namespace SetProject.Tests
{
    [TestFixture]
    public class SignUpTest : BaseTest
    {
        
        [TestCase (true, "Ihor", "Kordoba", "emai1@gmail.com", "password", "2010-10-10")]
        [TestCase (false, "Ihor", "Kordoba", "emai1@gmail.com", "password", "2010-10-10")]
        public void Test(bool isPositive, string firstName, string lastName, string email, string password, string birthdate)
        {
            HomePage mainPage = new HomePage(Driver);
            SignInPage signInPage = mainPage.ClickOnSignIn();
            SignUpPage signUpPage = signInPage.ClickOnSignUp().InputFirstName(firstName).InputLastName(lastName)
                .InputEmail(email).InputPassword(password).InputBirthdate(birthdate).InputCheckBox().ClickOnSave();
            bool isSignedUp = signUpPage.SignedUpCheck();
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