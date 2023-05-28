using OpenQA.Selenium;

namespace MailSelenium
{
    public class IndexMail: GmailBasePage
    {
        public IndexMail(IWebDriver driver, string url):base(driver)
        {
            Driver.Url = url;
        }

        public void WriteAMessange(string mail, string themeMessage, string message)
        {
            FindMailElement(Constants.BUTTON_WRITE_XPATH).Click();
            FindMailElement(Constants.INPUT_EMAIL_USER_XPATH).SendKeys(mail);
            FindMailElement(Constants.INPUT_THEME_XPATH).SendKeys(themeMessage);
            FindMailElement(Constants.INPUT_MESSAGE_XPATH).SendKeys(message);
            FindMailElement(Constants.SUBMIT_FORM_LATTER_XPATH).Click();
            FindMailElement(Constants.SEND_MESSAG_XPATH).Click();

        }

        public void ReadMessage(string message)
        {
           // Thread.Sleep(5000);
            var list = FindMessageElements(Constants.LIST_OF_UNREAD_MESSAGES).ToList();
            foreach (var element in list) 
            {
                if (element.Text.Contains(message))
                {
                    element.Click();
                    return;
                }
            }

            throw new Exception("Mesage not found");
        }
       
        public void ReplyOnMessage(string messageReply)
        {
            FindMailElement(Constants.BUTTON_REPLY_XPATH).Click();
            FindMailElement(Constants.INPUT_MESSAGE_TO_REPLY).SendKeys(messageReply);
            FindMailElement(Constants.SUBMIT_FORM_LATTER_XPATH).Click();
            FindMailElement(Constants.SEND_MESSAG_XPATH).Click();
        }

        public void ReturnToInbox()
        {
            //Thread.Sleep(500);
            FindMailElement(Constants.RETURN_TO_INBOX_TAB).Click();
           // Thread.Sleep(1000);
        }
        public void LogOutSystem()
        {
            Thread.Sleep(1000);
            Driver.Navigate().GoToUrl("https://accounts.google.com/Logout");
        }
        public void CloseDriver()
        {
            Driver.Quit();
        }

    }
}
