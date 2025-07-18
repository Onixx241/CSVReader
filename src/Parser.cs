using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.Text;

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

        foreach (PersonInfo person in people) 
        {
            names.Add(person.Name);
        }

        return names;
    }

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

}