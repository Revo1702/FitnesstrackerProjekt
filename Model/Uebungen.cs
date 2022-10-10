namespace Model
{
    public class Uebungen
    {
        private string _name { get; set; }
        private string _kategorie { get; set; }

        public Uebungen(string name, string kategorie)
        {
            _name = name;
            _kategorie = kategorie;
        }

        public Uebungen()
        {

        }
    }
}
