using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

public class TableDisplayer : IDisplay
{
    public Color tableColor { get; set; } = Color.White;

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

    public void Display(List<PersonInfo> people,bool isAlphabetical)
    {

        var table = new Table();

        table.AddColumn("Name");
        table.AddColumn("lastName");
        table.AddColumn("address");
        table.AddColumn("city");
        table.AddColumn("state");
        table.AddColumn("zip");

        table.Border = TableBorder.Rounded;
        table.BorderColor(this.tableColor);
        table.ShowRowSeparators = true;
        table.Centered();

        if (!isAlphabetical)
        {

            foreach (PersonInfo person in people)
            {
                table.AddRow(person.Name, person.lastName, person.address, person.city, person.state, person.zip);
            }

        }
        else if(isAlphabetical) 
        {
            foreach (PersonInfo person in this.listOfPeople.SortPeopleAlphabetically(people)) 
            {
                table.AddRow(person.Name, person.lastName, person.address, person.city, person.state, person.zip);
            }
        }



        AnsiConsole.Write(table);

    }
 
    public void DisplaySingleColumn(string columnName, Func<PersonInfo,string> property) 
    {

        var table = new Table();

        table.AddColumn(columnName);

        table.Border(TableBorder.HeavyHead);
        table.BorderColor(this.tableColor);

        table.Centered();

        table.Width = 75;

        foreach (string info in this.listOfPeople.GetColumn(Constants.filepath, property)) 
        {
            table.AddRow(info);
        }

        AnsiConsole.Write(table);

    }

    
}