using CsvHelper;
using CsvHelper.Configuration;
using Spectre.Console;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using Col = Spectre.Console.Color;

public class Program 
{
    public static void Main() 
    {
        Parser newparse = new Parser();

        TableDisplayer table = new TableDisplayer(newparse, Col.Aquamarine1);

        table.Display(newparse.GetPersonInfos(Constants.filepath), true);
        table.DisplaySingleColumn("Addresses", prop => prop.address);
        
    }
}


