using OpenQA.Selenium;

namespace MailSelenium
{
    public class IndexMail: GmailBasePage
    {
        string _message;

        public IndexMail(IWebDriver driver, string url):base(driver)
        {
            Driver.Url = url;
            _message = Constants.message;
        }

        public void WriteAMessange(string mail, string themeMessage)
        {
            FindMailElement(Constants.BUTTON_WRITE_XPATH).Click();
            FindMailElement(Constants.INPUT_EMAIL_USER_XPATH).SendKeys(mail);
            FindMailElement(Constants.INPUT_THEME_XPATH).SendKeys(themeMessage);
            FindMailElement(Constants.INPUT_MESSAGE_XPATH).SendKeys(_message);
            FindMailElement(Constants.SUBMIT_FORM_LATTER_XPATH).Click();
            FindMailElement(Constants.SEND_MESSAG_XPATH).Click();
           
        }

        public void ReadMessage()
        {
            FindMessageToRead(String.Format("//*[contains(text(),'{0}')]", _message)).Click();
        }
        public void ReplyOnMessage()
        {
            FindMailElement(Constants.BUTTON_REPLY_XPATH).Click();
            FindMailElement(Constants.INPUT_MESSAGE_TO_REPLY).SendKeys(Constants.responseMessage);
            FindMailElement(Constants.SUBMIT_FORM_LATTER_XPATH).Click();
            FindMailElement(Constants.SEND_MESSAG_XPATH).Click();
        }
        public void LogOutSystem()
        {
            Driver.Navigate().GoToUrl("https://accounts.google.com/Logout");
        }
        public void CloseDriver()
        {
            Driver.Quit();
        }

    }
}
