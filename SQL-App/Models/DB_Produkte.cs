using System;
using MySqlConnector;

namespace SQL_App.Models
{
    /// <summary>
    /// Dieses Skript kümmert sich um CRUD für Tabelle Produkte
    /// </summary>
    public class DB_Produkte
    {
        // enthält die daden für serveradresse, databankname, user, password
        public static string connectionString = "Server=127.0.0.1; Database = onlineshop; User = root; password=;";

        public static MySqlConnection connection;

        public static void Connect()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Connection success");
            }
            catch (Exception e)
            {
                Console.WriteLine("No!");
            }
        }

        public static void ReadAll()
        {
            string query = "SELECT * FROM produkte; ";

            // MySQLCommand Klasse um SQL Befehl an eine Connection zu schicken
            MySqlCommand command = new MySqlCommand(query, connection);


            // Führt den Command aus und speichert das Resultat
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Auf die aktuellen Spalten in der Zeile zugreifen
                string id = reader["id"].ToString();
                string artikelnummer = reader["artikelnummer"].ToString();
                string produktname = reader["produktname"].ToString();
                string preis = reader["preis"].ToString();
                string beschreibung = reader["beschreibung"].ToString();
                string anzahl = reader["anzahl"].ToString();

                Console.WriteLine(($"ID: {id} " + $"Artikelnummer: {artikelnummer} " + $"$Produktname: {produktname}" +
                                   $"Preis: {preis} " + $"Beschreibung {beschreibung} " + $"Anzahl: {anzahl} "));
            }
            
            command.Dispose();
            reader.Dispose();
        }

        public static Produkt GetProductByID(int id)
        {
            Produkt produkt = null;
            string query = "SELECT * FROM produkte WHERE id=" + id + "; ";

            // MySQLCommand Klasse um SQL Befehl an eine Connection zu schicken
            MySqlCommand command = new MySqlCommand(query, connection);


            // Führt den Command aus und speichert das Resultat
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Auf die aktuellen Spalten in der Zeile zugreifen
                int id2 = reader.GetInt32("id");
                int artikelnummer = reader.GetInt32("artikelnummer");
                string produktname = reader.GetString("produktname");
                double preis = reader.GetDouble("preis");
                string beschreibung = reader.GetString("beschreibung");
                int anzahl = reader.GetInt32("anzahl");

                produkt = new Produkt(id2, artikelnummer, produktname, preis, beschreibung, anzahl);
            }
            command.Dispose();
            reader.Dispose();
            return produkt;
        }

        /// <summary>
        /// Delete anhand der ID
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            string query = $"DELETE FROM `produkte` WHERE id={id}; ";
            MySqlCommand command = new MySqlCommand(query, connection);
            int rowsAfected = command.ExecuteNonQuery();
            if (rowsAfected > 0)
            {
                Console.WriteLine($"Datensatz gelöscht");
            }
            else
            {
                Console.WriteLine($"Konnte Produkt mit id: {id} nicht finden und löschen");
            }
            command.Dispose();
            
        }

        public static void Insert(Produkt produkt)
        {
            string query = "INSERT INTO produkte(artikelnummer, produktname, preis, beschreibung, anzahl) "
                           +
                           "VALUES (@artikelnummer, @produktname, @preis, @beschreibung, @anzahl); ";

            //Prepared Statements

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@artikelnummer", produkt.Artikelnummer);
            command.Parameters.AddWithValue("@produktname", produkt.Produktname);
            command.Parameters.AddWithValue("@preis", produkt.Preis);
            command.Parameters.AddWithValue("@beschreibung", produkt.Beschreibung);
            command.Parameters.AddWithValue("@anzahl", produkt.Anzahl);

            int rowsAfected = command.ExecuteNonQuery();

            if (rowsAfected > 0)
            {
                Console.WriteLine($"Datensatz wurde eingefügt!");
            }
            else
            {
                Console.WriteLine($"Fehler beim einfügen des Produktes");
            }
            command.Dispose();
           
        }

        public static void Update(Produkt produkt)
        {
            string query =
                $"UPDATE `produkte` SET artikelnummer=@artikelnummer, `produktname`=@produktname,`preis`=@preis,`beschreibung`=@beschreibung,`anzahl`=@anzahl WHERE id = @id; ";


            MySqlCommand command = new MySqlCommand(query, connection);


            command.Parameters.AddWithValue("@artikelnummer", produkt.Artikelnummer);
            command.Parameters.AddWithValue("@produktname", produkt.Produktname);
            command.Parameters.AddWithValue("@preis", produkt.Preis);
            command.Parameters.AddWithValue("@beschreibung", produkt.Beschreibung);
            command.Parameters.AddWithValue("@anzahl", produkt.Anzahl);
            command.Parameters.AddWithValue("@id", produkt.Id);
            
            int rowsAfected = command.ExecuteNonQuery();

            if (rowsAfected > 0)
            {
                Console.WriteLine($"Geklappt! =)");
            }
            else
            {
                Console.WriteLine($"Fehler =(");
            }
        }
    }
}

