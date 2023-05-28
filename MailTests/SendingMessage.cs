using MailSelenium;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data;

namespace MailTests
{
    [TestClass]
    public class SendingMessage
    {
        string themeMessage = "Test";
        string message = "Hello my friend";

        string messageReply = "Hi!!";

        [TestMethod]
        public void SendingMessagesAndMessageReplyPositive()
        {
            IWebDriver driver = new ChromeDriver();
            IndexMail indexMail = new IndexMail(driver, "https://www.google.com/intl/ru/gmail/about/");

            var user = new LogInPage(driver, "svetlanabojkomail@gmail.com", "14789@qz63");
            user.LogInSystem();
            indexMail.WriteAMessange("testsviatlana@gmail.com", themeMessage, message);
            indexMail.LogOutSystem();
            indexMail.CloseDriver();

            IWebDriver driverSecondUser = new ChromeDriver();
            IndexMail indexMailSecondUser = new IndexMail(driverSecondUser, "https://www.google.com/intl/ru/gmail/about/");

            var user2 = new LogInPage(driverSecondUser, "testsviatlana@gmail.com", "369741&K");
            user2.LogInSystem();
            indexMailSecondUser.ReadMessage(message);
            indexMailSecondUser.ReplyOnMessage(messageReply);
            indexMailSecondUser.ReturnToInbox();
            indexMailSecondUser.LogOutSystem();
            indexMailSecondUser.CloseDriver();

            IWebDriver driverUserFirstUser = new ChromeDriver();
            IndexMail indexMailFirstUser = new IndexMail(driverUserFirstUser, "https://www.google.com/intl/ru/gmail/about/");

            var userCheck = new LogInPage(driverUserFirstUser, "svetlanabojkomail@gmail.com", "14789@qz63");

            userCheck.LogInSystem();
            indexMailFirstUser.ReadMessage(messageReply);
            indexMailFirstUser.ReturnToInbox();
            indexMailFirstUser.LogOutSystem();
            indexMailFirstUser.CloseDriver();
        }

        //[TestMethod]
        //public void AFirstUserLogInSystemAndWriteMessagePositive()
        //{
        //    IWebDriver driver = new ChromeDriver();
        //    IndexMail indexMail = new IndexMail(driver, "https://www.google.com/intl/ru/gmail/about/");

        //    var user = new LogInPage(driver,"svetlanabojkomail@gmail.com", "14789@qz63");
        //    user.LogInSystem();
        //    indexMail.WriteAMessange("testsviatlana@gmail.com", themeMessage, message);
        //    indexMail.LogOutSystem();
        //    indexMail.CloseDriver();
        //}

        //[TestMethod]
        //public void BSecondUserLogInSystemAndReplyOnMessegePositive()
        //{
        //    IWebDriver driver = new ChromeDriver();
        //    IndexMail indexMail = new IndexMail(driver, "https://www.google.com/intl/ru/gmail/about/");

        //    var user2 = new LogInPage(driver,"testsviatlana@gmail.com", "369741&K");
        //    user2.LogInSystem();
        //    indexMail.ReadMessage(message);
        //    indexMail.ReplyOnMessage(messageReply);
        //    indexMail.ReturnToInbox();
        //    indexMail.LogOutSystem();
        //    indexMail.CloseDriver(); 
        //}

        //[TestMethod]
        //public void CheckingMessageForTheFirstUserPositive()
        //{
        //    IWebDriver driver = new ChromeDriver();
        //    IndexMail indexMail = new IndexMail(driver, "https://www.google.com/intl/ru/gmail/about/");

        //    var user = new LogInPage(driver,"svetlanabojkomail@gmail.com", "14789@qz63");

        //    user.LogInSystem();
        //    indexMail.ReadMessage(messageReply);
        //    indexMail.ReturnToInbox();
        //    indexMail.LogOutSystem();
        //    indexMail.CloseDriver();
        //}

    }
}
