using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using static System.Net.Mime.MediaTypeNames;

namespace MailSelenium
{
    internal class IndexMail: GmailBasePage
    {
        string _message;

        public IndexMail(IWebDriver driver, string url):base(driver)
        {
            _driver.Url = url;
            _message = Constants.message;
        }

        public void WriteAMessange()
        {
            FindMailElement(Constants.BUTTON_WRITE_XPATH).Click();
            FindMailElement(Constants.INPUT_EMAIL_USER_XPATH).SendKeys("testsviatlana@gmail.com");
            FindMailElement(Constants.INPUT_THEME_XPATH).SendKeys("Message");
            FindMailElement(Constants.INPUT_MESSAGE_XPATH).SendKeys(_message);
            FindMailElement(Constants.SUBMIT_FORM_LATTER_XPATH).Click();
            FindMailElement("//*[text()='Сообщение отправлено.']").Click();
           
        }

        public void ReadMessage()
        {  
            Thread.Sleep(2000);
            FindMessageToRead(String.Format("//*[contains(text(),'{0}')]", _message)).Click();

            //FindMessageElements("//tr[@class='zA zE']").ToList().ForEach((x =>
            //{
            //    if (x.Text.Contains(_message))
            //    {
            //       x.Click();
            //    }

            //}));

        }
        public void ReplyOnMessage()
        {
            FindMailElement(Constants.BUTTON_REPLY_XPATH).Click();
            FindMailElement(Constants.INPUT_MESSAGE_TO_REPLY).SendKeys("Hi!" + DateTime.Now);
            FindMailElement(Constants.SUBMIT_FORM_LATTER_XPATH).Click();
            FindMailElement("//*[text()='Сообщение отправлено.']").Click();
        }
        public void LogOutSystem()
        {
          // FindMailElement(Constants.AKAUNT_GOOGLE_XPATH).Click();


            //_driver.FindElement(By.XPath(Constants.AKAUNT_GOOGLE_XPATH)).Click();
           // _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Constants.AKAUNT_GOOGLE_XPATH))).Click();
            _driver.Navigate().GoToUrl("https://accounts.google.com/Logout");
            //_driver.FindElement(By.XPath(LOGOUT_XPATH)).Click();
        }
        public void CloseDriver()
        {
            _driver.Quit();
        }

    }
}
