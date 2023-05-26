using WebDriverDevBy.Pages;

namespace WebDriverDevBy;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //1 open main page
        IndexPage indexPage = new IndexPage();
        indexPage.Initialize();

        //2 switch vacancies page 
        VacanciesPage vacanciesPage = indexPage.SwitchToVacanciesPage();

        //3 count  all  vacancies on page and print on Console
        List<CollectionWrapper> collectionWrappers = new List<CollectionWrapper>();
        collectionWrappers = vacanciesPage.GetCountVacancies();
        collectionWrappers.ToList().ForEach(x => Console.WriteLine(x));

        Console.WriteLine("\n");

        //4 sor vacancies on page and print on Console
        List<CollectionWrapper> collectionSortByDescending = vacanciesPage.SortByDescending();
        collectionSortByDescending.ToList().ForEach(x => Console.WriteLine(x));

        //5 compare by the number of vacancies from the IndexPage
        Console.WriteLine("\nIndex = " + indexPage.numberVacancies + "\n" + "Vacancies = " + vacanciesPage.NumberVacanciesOnVacanciesPage + "\n");
        Console.WriteLine(indexPage.numberVacancies == vacanciesPage.NumberVacanciesOnVacanciesPage);

        indexPage.CloseDriver();
    }
}