using System;
using System.Data;
namespace LibraryManagement;
class Program{
    public static void Main(string[] args)
    {
        
        Operations.defaultData();
        Operations.MainMenu();
        // DateTime a=DateTime.Now;
        // Console.WriteLine((a.AddDays(15)-a).Days);
        
    }
}

