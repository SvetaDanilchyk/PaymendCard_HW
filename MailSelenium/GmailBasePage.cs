using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace MailSelenium;

public abstract class GmailBasePage
{
    protected IWebDriver _driver;
    protected WebDriverWait _wait;
     
    protected GmailBasePage(IWebDriver driver) 
    {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
    }

    protected IWebElement FindMailElement(string xPath)
    {
        return _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPath)));
    }
    protected IWebElement FindMessageToRead(string xPath)
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(600));
        return wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPath)));
    }
    protected ReadOnlyCollection <IWebElement> FindMessageElements(string xPath)
    {
        return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xPath)));
    }


}
