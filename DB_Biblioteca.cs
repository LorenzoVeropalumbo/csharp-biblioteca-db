using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Data.SqlClient;

static class DB_Biblioteca
{
    private static SqlConnection connessione;
    public static void Connect()
    {
        string stringaDiConnessione = "Data Source = localhost; Initial Catalog = db-biblioteca; Integrated Security = True";
        SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione);
        connessioneSql.Open();
        connessione = connessioneSql;
    }

    public static void AddToDatabaseLibro(Libri libroToAdd)
    {
        DB_Biblioteca.Connect();
        string insertQuery = "INSERT INTO Libri (Titolo,Anno,Stato,Settore,Scaffale,Autore,Codice_identificativo,Numero_pagine) VALUES (@Titolo,@Anno,@Stato,@Settore,@Scaffale,@Autore,@Codice_identificativo,@Numero_pagine)";

        SqlCommand insertCommand = new SqlCommand(insertQuery, connessione);
        insertCommand.Parameters.Add(new SqlParameter("@Titolo", libroToAdd.Titolo));
        insertCommand.Parameters.Add(new SqlParameter("@Anno", libroToAdd.Anno));
        insertCommand.Parameters.Add(new SqlParameter("@Stato", libroToAdd.Stato));
        insertCommand.Parameters.Add(new SqlParameter("@Settore", libroToAdd.Settore));
        insertCommand.Parameters.Add(new SqlParameter("@Scaffale", libroToAdd.Scaffale));
        insertCommand.Parameters.Add(new SqlParameter("@Autore", libroToAdd.Autore));
        insertCommand.Parameters.Add(new SqlParameter("@Codice_identificativo", libroToAdd.CodiceIdentificativo));
        insertCommand.Parameters.Add(new SqlParameter("@Numero_pagine", libroToAdd.NumeroDiPagine));

        int affectedRows = insertCommand.ExecuteNonQuery();
        connessione.Close();
    }

    public static void AddToDatabaseDvd(DvD DvdToAdd)
    {
        DB_Biblioteca.Connect();
        string insertQuery = "INSERT INTO Dvd (Titolo,Anno,Stato,Settore,Scaffale,Autore,Codice_identificativo,Durata) VALUES (@Titolo,@Anno,@Stato,@Settore,@Scaffale,@Autore,@Codice_identificativo,@Durata)";

        SqlCommand insertCommand = new SqlCommand(insertQuery, connessione);
        insertCommand.Parameters.Add(new SqlParameter("@Titolo", DvdToAdd.Titolo));
        insertCommand.Parameters.Add(new SqlParameter("@Anno", DvdToAdd.Anno));
        insertCommand.Parameters.Add(new SqlParameter("@Stato", DvdToAdd.Stato));
        insertCommand.Parameters.Add(new SqlParameter("@Settore", DvdToAdd.Settore));
        insertCommand.Parameters.Add(new SqlParameter("@Scaffale", DvdToAdd.Scaffale));
        insertCommand.Parameters.Add(new SqlParameter("@Autore", DvdToAdd.Autore));
        insertCommand.Parameters.Add(new SqlParameter("@Codice_identificativo", DvdToAdd.CodiceIdentificativo));
        insertCommand.Parameters.Add(new SqlParameter("@Durata", DvdToAdd.Durata));

        int affectedRows = insertCommand.ExecuteNonQuery();
        connessione.Close();
    }

    public static int SearchTable(string table, string searchValue)
    {
        DB_Biblioteca.Connect();
        string query = "SELECT * FROM " + table + " WHERE Titolo = '" + searchValue + "' OR Codice_identificativo = '" + searchValue + "'";
        SqlCommand cmd = new SqlCommand(query, connessione);

        SqlDataReader reader = cmd.ExecuteReader();
        bool disp = false;
        int id = 0;
        while (reader.Read())
        {
            id = reader.GetInt32(0);
            string name = reader.GetString(1);
            Int16 val = reader.GetInt16(2);
            disp = reader.GetBoolean(3);
            Console.WriteLine(name, val, disp);
        }

        connessione.Close();

        if (disp)
        {
            return id;
        }
        else
        {
            return -1;
        }  
        
    }

    public static void VediTuttiIDati()
    {
        // Query
        string query = "SELECT * FROM Libri,Dvd;";
        SqlCommand cmd = new SqlCommand(query, connessione);

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string nome = reader.GetString(1);
            Console.WriteLine(nome);
        }

        connessione.Close();
    }

    public static void GetPrestito(string insertResponse, int ObjId, int UserId)
    {
        DB_Biblioteca.Connect();

        if(insertResponse == "Libri")
        {
            string insertQuery = "INSERT INTO Prestiti (libri_id, user_id) VALUES (@libri_id,@user_id)";
            SqlCommand insertCommand = new SqlCommand(insertQuery, connessione);
      
            insertCommand.Parameters.Add(new SqlParameter("@libri_id", ObjId));
            insertCommand.Parameters.Add(new SqlParameter("@user_id", UserId));
            int affectedRows = insertCommand.ExecuteNonQuery();

            string insertQueryUpdate = " UPDATE "+ insertResponse + " SET [Stato] = @value WHERE id = " + ObjId;
            insertCommand = new SqlCommand(insertQueryUpdate, connessione);
            insertCommand.Parameters.Add(new SqlParameter("@value", false));
            int updatedRows = insertCommand.ExecuteNonQuery();
        }
        else 
        {
            string insertQuery = "INSERT INTO Prestiti (dvd_id, user_id) VALUES (@dvd_id,@user_id)";
            SqlCommand insertCommand = new SqlCommand(insertQuery, connessione);

            insertCommand.Parameters.Add(new SqlParameter("@dvd_id", ObjId));
            insertCommand.Parameters.Add(new SqlParameter("@user_id", UserId));
            int affectedRows = insertCommand.ExecuteNonQuery();

            string insertQueryUpdate = " UPDATE " + insertResponse + " SET Stato = False WHERE id = " + ObjId;
            insertCommand = new SqlCommand(insertQueryUpdate, connessione);
            affectedRows = insertCommand.ExecuteNonQuery();
        } 
        connessione.Close();
    }
}