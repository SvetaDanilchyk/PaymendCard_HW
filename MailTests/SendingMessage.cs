using MailSelenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MailTests
{
    [TestClass]
    public class SendingMessage
    {
        [TestMethod]
        public void AFirstUserLogInSystemAndWriteMessagePositive()
        {
            IWebDriver driver = new ChromeDriver();
            IndexMail indexMail = new IndexMail(driver, "https://www.google.com/intl/ru/gmail/about/");

            var user = new LogInPage(driver, "Svetlana Bojko", "svetlanabojkomail@gmail.com", "14789@qz63");

            user.LogInSystem();
            indexMail.WriteAMessange("testsviatlana@gmail.com", "Amd");
            indexMail.LogOutSystem();
            indexMail.CloseDriver();
        }

        [TestMethod]
        public void BSecondUserLogInSystemAndReplyOnMessegePositive()
        {
            IWebDriver driver = new ChromeDriver();
            IndexMail indexMail = new IndexMail(driver, "https://www.google.com/intl/ru/gmail/about/");

            var user2 = new LogInPage(driver, "Sviatlana Danilchyk", "testsviatlana@gmail.com", "369741&K");
            user2.LogInSystem();
            indexMail.ReadMessage();
            indexMail.ReplyOnMessage();
            indexMail.LogOutSystem();
            indexMail.CloseDriver(); ;
        }

        [TestMethod]
        public void CheckingMessageForTheFirstUserPositive()
        {
            IWebDriver driver = new ChromeDriver();
            IndexMail indexMail = new IndexMail(driver, "https://www.google.com/intl/ru/gmail/about/");

            var user = new LogInPage(driver, "Svetlana Bojko", "svetlanabojkomail@gmail.com", "14789@qz63");

            user.LogInSystem();
            indexMail.ReadMessage();
            indexMail.LogOutSystem();
            indexMail.CloseDriver();
        }

    }
}