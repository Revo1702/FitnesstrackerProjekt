using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnesstracker
{
    class Uebung
    {
        private string _uebungsName { get; set; }
        private double _gewicht { get; set; }
        private int _wiederholungen { get; set; }
        public Uebung(string uebungsname, double gewicht, int wiederholungen)
        {
            _uebungsName = uebungsname;
            _gewicht = gewicht;
            _wiederholungen = wiederholungen;
        }
        public Uebung()
        {

        }

        public Uebung(string uname)
        {
            _uebungsName = uname;
        }

        public void WriteToDatabase()
        {

        }
    }
}
