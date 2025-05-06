using System;
using System.Globalization;
using System.Net.Mime;
using SQL_App.Models;

namespace SQL_App.Views
{
    public class Anzeige
    {
        public static void MainMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("Bitte wählen Sie aus");
            Console.WriteLine("[1] Produkte");
            Console.WriteLine("[2] Einstellungen");
            Console.WriteLine("[3] Beenden");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    ProdukteMenu();
                    break;
                case 2:
                    Einstellungen();
                    break;
                case 3:
                    Beenden();
                    break;
            }
        }

        public static void ProdukteMenu()
        {
            Console.WriteLine("Produkte Menu");
            Console.WriteLine("Bitte wählen Sie aus");
            Console.WriteLine("[1] Read All");
            Console.WriteLine("[2] Insert");
            Console.WriteLine("[3] Update");
            Console.WriteLine("[4] Delete");
            Console.WriteLine("[5] Zurück");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    
                    DB_Produkte.ReadAll();
                    bool read = true;
                    do
                    {
                        Console.WriteLine("Wollen Sie zurück? [J] für Ja, [N] für Nein");
                        string antwort = Console.ReadLine();


                        switch (antwort)
                        {
                            case "J":
                                MainMenu();
                                read = false;
                                break;
                            
                            case "N":
                                DB_Produkte.ReadAll();
                                break;
                        }
                    } while (read == true); 
                    break;
                case 2:
                    ProdukteInsert();
                    break;
                case 3:
                    ProdukteUpdate();
                    break;
                case 4:
                    Delete();
                    break;
                case 5:
                    MainMenu();
                    break;
            }
        }

        public static void Delete()
        {
            bool delete = true;
            do
            {
                Console.WriteLine("ID");
                Console.WriteLine("Bitte fügen Sie Id ein oder [12345] für Exit");
                
                int idInput = Convert.ToInt32(Console.ReadLine());
                if (idInput == 12345)
                {
                    delete = false;
                    ProdukteMenu();
                    
                }

                DB_Produkte.Delete(idInput);
            } while (delete==true);
        }

        public static void ProdukteInsert()
        {
            bool insert = true;
            do
            {
                Console.WriteLine("Bitte geben Sie die ArtikelNummer ein: ");
                int artikelnummer = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Bitte geben Sie die Produktname ein: ");
                string produktname = Console.ReadLine();

                Console.WriteLine("Bitte geben Sie die Preis ein: ");
                double preis = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Bitte geben Sie die Beschreibung ein: ");
                string beschreibung = Console.ReadLine();

                Console.WriteLine("Bitte geben Sie die Anzahl ein: ");
                int anzahl = Convert.ToInt32(Console.ReadLine());

                Produkt tempprodukt = new Produkt(artikelnummer, produktname, preis, beschreibung, anzahl);

                DB_Produkte.Insert(tempprodukt);
                Console.WriteLine("Wollen Sie noch ein Produkt einfügen? [J] für Ja, [N] für Exit");
                string weiter = Console.ReadLine();
                if (weiter == "N")
                {
                    insert = false;
                    ProdukteMenu();
                    
                }
            } while (insert == true);
        }

        public static void ProdukteUpdate()
        {
            DB_Produkte.ReadAll();

            Console.WriteLine("Wählen Sie das Produkt (ID)");
            int id = Convert.ToInt32(Console.ReadLine());

            Produkt produkt = DB_Produkte.GetProductByID(id);
            

            string label = "";
            bool update = true;


            do
            {
                Console.WriteLine("Was genau wollen Sie ändern? ");
                Console.WriteLine("[A] für Artikelnummer ");
                Console.WriteLine("[B] für Produktname");
                Console.WriteLine("[C] für Preis ");
                Console.WriteLine("[D] für Beschreibung ");
                Console.WriteLine("[E] für Anzahl ");
                Console.WriteLine("[Z] für Menu zu schliesen ");
                
                string wahl = Console.ReadLine();
                
                if (wahl == "A")
                {
                    Console.WriteLine("Aktuelle Artikelnummer: " + produkt.Artikelnummer);

                    Console.WriteLine("Neue Artikelnummer");
                    int artikelnummer = Convert.ToInt32(Console.ReadLine());
                    produkt.Artikelnummer = artikelnummer;
                }
                else if (wahl == "B")
                {
                    Console.WriteLine("Aktuelle Produktname: " + produkt.Produktname);

                    Console.WriteLine("Neue Produktname");
                    string produktname = Convert.ToString(Console.ReadLine());
                    produkt.Produktname = produktname;
                }
                else if (wahl == "C")
                {
                    Console.WriteLine("Aktuelle Preis: " + produkt.Preis);

                    Console.WriteLine("Neue Preis");
                    double preis = Convert.ToDouble(Console.ReadLine());
                    produkt.Preis = preis;
                }
                else if (wahl == "D")
                {
                    Console.WriteLine("Aktuelle Beschreibung: " + produkt.Beschreibung);

                    Console.WriteLine("Neue Beschreibung");
                    string beschreibung = Console.ReadLine();
                    produkt.Beschreibung = beschreibung;
                }
                else if (wahl == "E")
                {
                    Console.WriteLine("Aktuelle Anzahl: " + produkt.Anzahl);

                    Console.WriteLine("Neue Anzahl");
                    int anzahl = Convert.ToInt32(Console.ReadLine());
                    produkt.Anzahl = anzahl;
                }
                else if (wahl == "Z")
                {
                    update = false;
                    ProdukteMenu();
                    
                }

                DB_Produkte.Update(produkt);
            } while (update == true);
        }

        public static void Einstellungen()
        {
            bool eins = true;
            do
            {
                Console.WriteLine("Made by Nata Pavelko");
                Console.WriteLine("Version 1.0");
                Console.WriteLine("Zurück? [J] für Ja, [N] für Nein");
                string antwort = Console.ReadLine();
                if (antwort == "N")
                {
                    eins = true;
                }
                else if (antwort == "J")
                {
                    eins = false;
                    MainMenu();
                }
            } while (eins == true);
        }

        public static void Beenden()
        {
            System.Environment.Exit(0);
        }
    }
}