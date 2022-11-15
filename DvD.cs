public class DvD : Documenti
{
    public DvD(string titolo, int anno, string settore, bool stato, float scaffale, string autore, string numeroSeriale, float durata) : base(titolo, anno, settore, stato, scaffale, autore, numeroSeriale)
    {
        Durata = durata;
    }

    public float Durata { set; get; }
}