namespace SQL_App.Models
{
    public class Produkt
    {
        private int id;
        private int artikelnummer;
        private string produktname;
        private double preis;
        private string beschreibung;
        private int anzahl;


        public Produkt(int id, int artikelnummer, string produktname, double preis, string beschreibung, int anzahl)
        {
            this.id = id;
            this.artikelnummer = artikelnummer;
            this.produktname = produktname;
            this.preis = preis;
            this.beschreibung = beschreibung;
            this.anzahl = anzahl;
        }

        public Produkt(int artikelnummer, string produktname, double preis, string beschreibung, int anzahl)
        {
            this.artikelnummer = artikelnummer;
            this.produktname = produktname;
            this.preis = preis;
            this.beschreibung = beschreibung;
            this.anzahl = anzahl;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int Artikelnummer
        {
            get => artikelnummer;
            set => artikelnummer = value;
        }

        public string Produktname
        {
            get => produktname;
            set => produktname = value;
        }

        public double Preis
        {
            get => preis;
            set => preis = value;
        }

        public string Beschreibung
        {
            get => beschreibung;
            set => beschreibung = value;
        }

        public int Anzahl
        {
            get => anzahl;
            set => anzahl = value;
        }
    }
}