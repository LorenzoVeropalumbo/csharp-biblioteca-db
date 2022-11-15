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
    }

    public static void AddToDatabaseDvd(DvD DvdToAdd)
    {
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
    }

    public static void AddToDatabaseLibro(string table, string searchValue)
    {
        string query = "SELECT * FROM " + table + " WHERE Titolo = '" + searchValue + "' OR Codice_identificativo = '" + searchValue + "'";
        SqlCommand cmd = new SqlCommand(query, connessione);

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string nome = reader.GetString(1);
            Console.WriteLine(nome);
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
    }
}