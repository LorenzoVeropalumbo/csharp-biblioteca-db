public class Documenti
{
    public Documenti(string titolo, int anno, string settore, bool stato, float scaffale, string autore, string codiceIdentificativo)
    {
        Titolo = titolo;
        Anno = anno;
        Settore = settore;
        Stato = stato;
        Scaffale = scaffale;
        Autore = autore;
        CodiceIdentificativo = codiceIdentificativo;
    }

    public string CodiceIdentificativo { set; get; }
    public string Titolo { set; get; }
    public int Anno { set; get; }
    public string Settore { set; get; }
    public bool Stato { set; get; }
    public float Scaffale { set; get; }
    public string Autore { set; get; }

}
