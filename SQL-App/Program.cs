using SQL_App.Models;
using SQL_App.Views;

namespace SQL_App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           DB_Produkte.Connect();
           Anzeige.MainMenu();
        }
    }
}