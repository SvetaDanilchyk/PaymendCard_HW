
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace WebDriverDevBy.Pages;

internal class VacanciesPage
{
    IWebDriver _driver;
    WebDriverWait _wait;

    ReadOnlyCollection<IWebElement> vacancies;

    public List<CollectionWrapper> CollectionsVacancies;
    public int NumberVacanciesOnVacanciesPage { get; set; }

    public VacanciesPage(IWebDriver driver)
    {
        _driver = driver;
        CollectionsVacancies = new List<CollectionWrapper>();
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
    }

    public List<CollectionWrapper> GetCountVacancies()
    {

        vacancies = _driver.FindElements(By.XPath(Constans.VACANCIES_COLLECTIONS_XPATH));
        vacancies.ToList().ForEach(x =>
        {
            x.Click();
            Thread.Sleep(500);
            string strNameWithQuantity = _driver.FindElement(By.XPath(Constans.HEADER_VACANCIES_AND_QUANTITY)).Text;
            if (strNameWithQuantity != null)
            {
                string[] splitResult = strNameWithQuantity.Split(" ");
                CollectionsVacancies.Add(new CollectionWrapper
                                        (_driver.FindElement(By.XPath(Constans.NAME_VACANCIES)).Text,
                                        int.Parse(splitResult[0])));
            }
            else
            {
                CollectionsVacancies.Add(new CollectionWrapper
                                        (_driver.FindElement(By.XPath(Constans.NAME_VACANCIES)).Text, 0));
            }
        });

        GetNumberOfVacanciesOnVacanciesPage();

        return CollectionsVacancies;
    }

    public List<CollectionWrapper> SortByDescending()
    {
        List<CollectionWrapper> sortVacancies = new();

        sortVacancies = CollectionsVacancies.OrderByDescending(x => x.CountVacancies).ToList();

        return sortVacancies;
    }

    public void CloseInfoWindowOnVacanciesPage()
    {
        _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Constans.CLOSE_BUTTON_XPATH))).Click();
    }

    public void GetNumberOfVacanciesOnVacanciesPage()
    {
        NumberVacanciesOnVacanciesPage = CollectionsVacancies.Select(x => x.CountVacancies).Sum();
    }

}


