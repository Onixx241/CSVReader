using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IDisplay 
{
    public void Display(List<PersonInfo> person, bool isAlphabetical);
    public void DisplaySingleColumn(string columnName, Func<PersonInfo, string> property);

}