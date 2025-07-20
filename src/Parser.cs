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

    public List<string> GetColumn(string filepath, Func<PersonInfo, string> property)
    {

        List<PersonInfo> people = GetPersonInfos(filepath);
        List<string> list = new List<string>();
        //maybe make a separate sorted list for when sorting is activated.
        foreach (PersonInfo person in people)
        {
            list.Add(property(person));
        }

        return list;

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

