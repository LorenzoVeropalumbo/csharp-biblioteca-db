bool loop = true;
DB_Biblioteca.Connect();

while (loop)
{
	Console.WriteLine("BIBLIOTECA DB");
	Console.WriteLine();
	Console.WriteLine("Seleziona un opzione");
	Console.WriteLine("1. Inserisci un prodotto");
	Console.WriteLine("2. Ricarca un prodotto");
	Console.WriteLine("3. Noleggia un prodotto");
    Console.WriteLine("4. Log out");
    int response = Convert.ToInt32(Console.ReadLine());

	switch (response)
	{
		case 1:
            InsertLoop();       
            break;
        case 2:
            Console.WriteLine("Cosa vuoi cercare: \nLibri o Dvd");
            string insertResponse = Console.ReadLine();
            Console.WriteLine("Inserici il codice identificatico o il titolo");
            string query = Console.ReadLine();
            DB_Biblioteca.SearchTable(insertResponse, query);
            break;
        case 3:
            Prestito();
            break;
        default:
			Console.Clear();
			loop =	false;
			break;
	}
}

void InsertLoop()
{   
    Console.WriteLine("Cosa vuoi inserire: \n 1. Libro o 2. Dvd");
    int insertResponse = Convert.ToInt32(Console.ReadLine());
    AddToDb(insertResponse);
}

void AddToDb(int response)
{
	Console.WriteLine("inserisci il titolo: ");
	string Titolo = Console.ReadLine();
    Console.WriteLine("inserisci l'anno: ");
    int Anno = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("inserisci il settore: ");
    string Settore = Console.ReadLine();
    Console.WriteLine("inserisci lo scaffale: ");
    float Scaffale = float.Parse(Console.ReadLine());
    Console.WriteLine("inserisci l'autore: ");
    string Autore = Console.ReadLine();
    Console.WriteLine("inserisci il codice identificativo: ");
    string CodiceIdentificativo = Console.ReadLine();

    if(response == 1)
    {
        Console.WriteLine("inserisci il numero di pagine: ");
        int NumeroPagine = Convert.ToInt32(Console.ReadLine());
    
        Libri libro = new Libri(Titolo,Anno,Settore,true,Scaffale, Autore, CodiceIdentificativo,NumeroPagine);
	    DB_Biblioteca.AddToDatabaseLibro(libro);
    }
    else if (response == 2) 
    {
        Console.WriteLine("inserisci la durata: ");
        int Durata = Convert.ToInt32(Console.ReadLine());

        DvD DvD = new DvD(Titolo, Anno, Settore, true, Scaffale, Autore, CodiceIdentificativo, Durata);
        DB_Biblioteca.AddToDatabaseDvd(DvD);
    }
    else
    {
        throw new Exception("scelta non valida ripetere");
    }
}

void Prestito()
{
    Console.WriteLine("Cosa vuoi cercare: \nLibri o Dvd");
    string insertResponse = Console.ReadLine();
    Console.WriteLine("Inserici il codice identificatico o il titolo");
    string query = Console.ReadLine();
    int id = DB_Biblioteca.SearchTable(insertResponse, query);
    if(id == -1)
    {
        Console.WriteLine("Libro non disponibile");
        return;
    }
    Console.WriteLine("Inserici l'email");
    string UserEmail = Console.ReadLine();
    int User = DB_Biblioteca.GetUser(UserEmail);
    if(User == -1)
    {
        Console.WriteLine("Utente non disponibile registrati");
        return;
    }
    DB_Biblioteca.GetPrestito(insertResponse, id, User);
}