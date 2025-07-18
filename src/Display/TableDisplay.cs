using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

public class TableDisplayer : IDisplay
{
    public Color tableColor { get; set; } = Color.Black;

    Parser listOfPeople { get; set; }


    public TableDisplayer(Parser parser) 
    {
        this.listOfPeople = parser;
    }
    public TableDisplayer(Parser parser, Color tableColor) 
    {
        this.listOfPeople = parser;
        this.tableColor = tableColor;
    }

    public void Display()
    {

        var table = new Table();

        table.AddColumn("Name");
        table.AddColumn("lastName");
        table.AddColumn("address");
        table.AddColumn("city");
        table.AddColumn("state");
        table.AddColumn("zip");

        table.BorderColor(this.tableColor);
        table.ShowRowSeparators = true;
        table.Centered();

        foreach (PersonInfo person in this.listOfPeople.GetPersonInfos(Constants.filepath))
        {
            table.AddRow(person.Name, person.lastName, person.address, person.city, person.state, person.zip);
        }



        AnsiConsole.Write(table);

    }

    public void DisplayNames() 
    {

        var table = new Table();

        table.AddColumn("Names");

        table.Border(TableBorder.HeavyHead);
        table.BorderColor(this.tableColor);

        table.Centered();

        table.Width = 75;

        foreach (string name in this.listOfPeople.GetNames(Constants.filepath)) 
        {
            table.AddRow(name);
        }

        AnsiConsole.Write(table);

    }

    public void DisplayCities() 
    {
        var table = new Table();

        table.AddColumn("Cities");

        table.Border(TableBorder.HeavyHead);
        table.BorderColor(this.tableColor);

        table.Centered();

        table.Width = 75;


        foreach (string city in this.listOfPeople.GetCities(Constants.filepath)) 
        {
            table.AddRow(city);
        }

        AnsiConsole.Write(table);


    }
}