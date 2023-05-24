
namespace WebDriverDevBy.Pages;

internal class CollectionWrapper
{
    public string Name;
    public int CountVacancies;

    public CollectionWrapper(string name, int count)
    {
        Name = name;
        CountVacancies = count;
    }
    public override string ToString()
    {
        return String.Format("{0}   - {1}", Name, CountVacancies);
    }

}
