using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

public class Parser
{



    public List<PersonInfo> ParsePerson(string filepath)
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

    public void PrintCSV(string filepath) 
    {

        List<PersonInfo> people = ParsePerson(filepath);

        Console.WriteLine("Name | LastName | Address | City | State | Zip |");
        foreach (PersonInfo person in people) 
        {
            Console.WriteLine($"{person.Name} | {person.lastName} | {person.address} | {person.city} | {person.state} | {person.zip}");
        }

    }
}

public class Program 
{
    public static void Main() 
    {
        string filepath = "";

        Parser newparse = new Parser();
        newparse.PrintCSV(filepath);
    }
}

