using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.Text;
using System.Security.Cryptography;

public class Parser
{

    public List<PersonInfo> GetPersonInfos(string filepath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Encoding = Encoding.UTF8,
            Delimiter = ",",
            IgnoreBlankLines = false,
            HasHeaderRecord = true
        };

        using (var reader = new StreamReader(filepath))
        using (var csv = new CsvReader(reader, config))
        {
            return csv.GetRecords<PersonInfo>().ToList();
        }
    }

    //these two seem like DRY violations...
    public List<string> GetNames(string filepath)
    {
        List<PersonInfo> people = GetPersonInfos(filepath);
        List<string> names = new List<string>();
        //maybe make a separate sorted list for when sorting is activated.
        foreach (PersonInfo person in people)
        {
            names.Sort();
            names.Add(person.Name);
        }

        return names;
    }


    //maybe change these two params to take List<PersonInfo>
    public List<string> GetCities(string filepath)
    {
        List<PersonInfo> people = GetPersonInfos(filepath);
        List<string> cities = new List<string>();

        foreach (PersonInfo person in people)
        {
            cities.Add(person.city);
        }

        return cities;
    }

    public List<PersonInfo> SortPeopleAlphabetically(List<PersonInfo> people)
    {

        IEnumerable<PersonInfo> unsorted = people.OrderBy(people => people.Name);
        List<PersonInfo> sorted = new List<PersonInfo>();

        foreach (PersonInfo person in unsorted)
        {
            sorted.Add(person);
        }

        return sorted;
    }

}