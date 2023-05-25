
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace WebDriverDevBy.Pages;

internal class VacanciesPage
{
    IWebDriver _driver;

    ReadOnlyCollection<IWebElement> vacancies;
    public List<CollectionWrapper> CollectionsVacancies;

    const string VACANCIES_COLLECTIONS_XPATH = "//a[@class='collections__item gtm-track-collection-click']";
    const string VACANCIES_PAGE_WINDOWB_XPATH = "//button[@class = 'wishes-popup__button-close wishes-popup__button-close_icon']";//= 'submit'

    const string VAC_PAGE = "//label[@class='collection_radio_buttons']"; 
    public int numberVacanciesOnVacanciesPage { get; set; }
    public VacanciesPage(IWebDriver driver)
    {
        _driver = driver;
        CollectionsVacancies = new List<CollectionWrapper>();
    }
    public List<CollectionWrapper> GetCountVacancies()
    {

        vacancies = _driver.FindElements(By.XPath(VAC_PAGE));
        vacancies.ToList().ForEach(x =>
        {
            x.Click();
            Thread.Sleep(500);
            string strNameWithQuantity = _driver.FindElement(By.XPath("//h1[@class='vacancies-list__header-title']")).Text;
            if (strNameWithQuantity != null)
            {
                String[] splitResult = strNameWithQuantity.Split(" ");
                CollectionsVacancies.Add(new CollectionWrapper
                                        (_driver.FindElement(By.XPath("//span[@class='vacancies-list__filter-tag__text']")).Text,
                                        Int32.Parse(splitResult[0])));
            }
            else
            {
                CollectionsVacancies.Add(new CollectionWrapper
                                        (_driver.FindElement(By.XPath("//span[@class='vacancies-list__filter-tag__text']")).Text, 0));
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
        Thread.Sleep(3000);
        var buttonCloseWindow = _driver.FindElement(By.XPath(VACANCIES_PAGE_WINDOWB_XPATH));
        buttonCloseWindow.Click();
    }

    public void GetNumberOfVacanciesOnVacanciesPage()
    {
        numberVacanciesOnVacanciesPage = CollectionsVacancies.Select(x => x.CountVacancies).Sum();
    }

}


