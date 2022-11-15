public class Libri : Documenti
{
    public Libri(string titolo, int anno, string settore, bool stato, float scaffale, string autore, string ISBN, int numeroDiPagine) : base(titolo, anno, settore, stato, scaffale, autore, ISBN)
    {
        NumeroDiPagine = numeroDiPagine;
    }

    public int NumeroDiPagine { set; get; }
}