using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TorneoGolf
{
    public class PartecipantiRepository : IPartecipantiDbManager
    {
        { 
            const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                             "Initial Catalog = TorneoGolf" +
                                             "Integrated Security = true;";

            const string _discriminator = "Partecipante";


        public static List<Partecipante> Fetch()
        {
            List<Partecipante> partecipante = new List<Partecipante>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Partecipante where Discriminator = @discriminator";
                command.Parameters.AddWithValue("@discriminator", _discriminator);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];
                    var nascita = (DateTime)reader["DataNascita"];
                    var tesserato = (bool)reader["Tesserato"];
                    var id = (int)reader["IdPartecipante"];

                    Partecipante part = new Partecipante(nome, cognome, Sesso, nascita, tesserato, id);
                    partecipante.Add(part);
                }
            }
            return partecipante;
        }

        public static void Delete(Partecipante partecipante)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "delete from Vehicle where Id = @id";
                    command.Parameters.AddWithValue("@id", Partecipante.id);

                    command.ExecuteNonQuery();
                }
            }

            public static Partecipante GetByNomeCognome(Partecipante part)
            {
                Partecipante newpart = new Partecipante();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from Partecipante where Id = @IdPartecipante";
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                {
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];
                    var nascita = (DateTime)reader["DataNascita"];
                    var tesserato = (bool)reader["Tesserato"];
                    var id = (int)reader["IdPartecipante"];

                    part = new Partecipante(nome, cognome, nascita, tesserato, id);
                    }
                }
                return part;
            }

            public static Partecipante NuovoPartecipante(Partecipante part)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;

                     command.CommandText = "Inserisci i valori @nome, @cognome, @datanascita, @sesso, @discriminator)";
                    command.Parameters.AddWithValue("@nome", Partecipante.Nome);
                    command.Parameters.AddWithValue("@cognome", Partecipante.Cognome);
                    command.Parameters.AddWithValue("@datanascita", Partecipante.DataNascita);
                    command.Parameters.AddWithValue("@sesso", Partecipante.Sesso);
                     command.Parameters.AddWithValue("@seats", DBNull.Value);
                    command.Parameters.AddWithValue("@discriminator", _discriminator);

                    command.ExecuteNonQuery();
                }
            return part;
            }

            public void EditPartecipante(Partecipante partecipante)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "update Partecipante " +
                                          "set Nome = @nome, Cognome = @cognome, DataNascita = @datanascita, Sesso = @sesso";
                    command.Parameters.AddWithValue("@nome", Partecipante.Nome);
                    command.Parameters.AddWithValue("@cognome", Partecipante.Cognome);
                    command.Parameters.AddWithValue("@datanascita", DBNull.Value);
                    command.Parameters.AddWithValue("@sessi", DBNull.Value);
                    command.Parameters.AddWithValue("@discriminator", _discriminator);

                    command.ExecuteNonQuery();
                }
            }
        }
    }