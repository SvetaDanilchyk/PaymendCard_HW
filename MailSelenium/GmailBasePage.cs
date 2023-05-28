using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace MailSelenium;

public abstract class GmailBasePage
{
    protected IWebDriver Driver;
    protected WebDriverWait Wait;
     
    protected GmailBasePage(IWebDriver driver) 
    {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(90));
    }

    protected IWebElement FindMailElement(string xPath)
    {
        return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
    }

    protected ReadOnlyCollection <IWebElement> FindMessageElements(string xPath)
    {
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(600));

        return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xPath)));
    }


}
