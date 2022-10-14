namespace Model
{
    public class Uebungen
    {
        public string Name { get; set; }
        public string Kategorie { get; set; }

        public Uebungen(string name, string kategorie)
        {
            Name = name;
            Kategorie = kategorie;
        }

        public Uebungen()
        {
            
        }
    }
}
