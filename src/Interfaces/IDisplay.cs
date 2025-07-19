using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IDisplay 
{
    public void Display(List<PersonInfo> person, bool isAlphabetical);
    public void DisplayNames();
    public void DisplayCities();

}