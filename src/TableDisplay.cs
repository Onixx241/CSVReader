using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

//finish implementing IDisplay methods
public class TableDisplayer
{
    public Color tableColor { get; set; }

    Parser listOfPeople { get; set; }


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

        table.BorderColor(this.tableColor);

        table.Centered();

        table.Width = 75;

        //align text?

        foreach(PersonInfo person in this.listOfPeople.GetPersonInfos(Constants.filepath)) 
        {
            table.AddRow(person.Name);
        }

        AnsiConsole.Write(table);
    }
}