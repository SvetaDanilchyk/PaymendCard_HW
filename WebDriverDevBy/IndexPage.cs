using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection.Emit;

namespace WebDriverDevBy.Pages;

internal class IndexPage : Constans
{
    IWebDriver _driver;
    IWebElement _vacancieesLink;

    public int numberVacancies { get; set; }

    public IndexPage()
    {
        _driver = new ChromeDriver();
        _driver.Url = "https://devby.io/";        
    }

    public void Initialize()
    {
        _vacancieesLink = _driver.FindElement(By.XPath(Constans.VACANCIES_PAGE_XPATH));
        GetNumberOfVacancies();
    }

    //public void GetNumberOfVacancies()
    //{
    //    var vacanciesCount = _driver.FindElements(By.XPath(Constans.NUMBER_OF_VACANCIES_XPATH)).First().Text;
    //    String[] stringVacanciesCount = vacanciesCount.Split(" ");
    //    numberVacancies = Int32.Parse(stringVacanciesCount[0]);

    //}

    public void GetNumberOfVacancies()
    {
        var vacanciesCount = _driver.FindElements(By.XPath(Constans.NUMBER_VACANCIES)).First().GetAttribute("data-label");
        numberVacancies = int.Parse(vacanciesCount);
    }

    public VacanciesPage SwitchToVacanciesPage()
    {
        _vacancieesLink.Click();
        new VacanciesPage(_driver).CloseInfoWindowOnVacanciesPage();
        return new VacanciesPage(_driver);

    }

    public void CloseDriver() 
    {
        _driver.Close();
    }

}


