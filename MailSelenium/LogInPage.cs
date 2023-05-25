using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace MailSelenium;

internal class LogInPage : GmailBasePage
{
    string Name;
    public string Password;
    public string Mail;   

    public LogInPage(IWebDriver driver, string name, string mail, string password):base(driver)
    {
        Name = name;
        Mail = mail;
        Password = password;
    }

    public void LogInSystem()
    {
        FindMailElement(Constants.LOGIN_IN_XPATH).Click();

        FindMailElement(Constants.INPUT_EMAIL_XPATH).SendKeys(Mail);
        FindMailElement(Constants.BUTTON_NEXT_XPATH).Click();
                
        _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Constants.INPUT_PASSWORD_XPATH))).SendKeys(Password);
        FindMailElement(Constants.BUTTON_NEXT_XPATH).Click();
        //_driver.FindElement(By.XPath(Constants.BUTTON_NEXT_XPATH)).Click();
    }
    
}
