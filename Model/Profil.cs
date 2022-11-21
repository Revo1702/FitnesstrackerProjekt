using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Profil
    {
        private string _name { get; set; }
        private string _nachnahme { get; set; }
        private int _alter { get; set; }
        private double _groesse { get; set; }
        private double _gewicht { get; set; }
        
        public Profil (string name, string nachnahme,int alter, double groesse, double gewicht)
        {
            _name = name;
            _nachnahme = nachnahme;
            _alter = alter;
            _groesse = groesse;
            _gewicht = gewicht;
        }
        public Profil (string name, int alter, double groesse, double gewicht)
        {
            _name = name;
            _alter = alter;
            _groesse = groesse;
            _gewicht = gewicht;
        }
        public Profil(int alter, double groesse, double gewicht)
        {
            _alter = alter;
            _groesse = groesse;
            _gewicht = gewicht;
        }
        public Profil()
        {

        }
    }
}
