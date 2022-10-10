using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Berechnungen
    {
        public static double BerechneOneRepMax(int wdh, double gewicht)
        {
            double oneRepMax;



            double brzycki = gewicht * (36 / (37 - wdh));
            double epley = gewicht * (1 + 0.0333 * wdh);
            double lander = (100 * gewicht) / (101.3 - 2.67123 * wdh);
            oneRepMax = (brzycki + epley + lander) / 3;
            oneRepMax = Math.Round(oneRepMax, 2);



            return oneRepMax;
        }

        public static string BerechneGewichtsplatten(double gewicht, double stangegewicht)
        {
            int zwanzigKGPlatte = 0;
            int zehnKGPlatte = 0;
            int fuenfKGPlatte = 0;
            int zweikommafuenfKGPlatte = 0;
            int einskommazweifuenfKGPlatte = 0;



            string erg;

            if (gewicht % 0.5 == 0)
            {
                if (gewicht % 1.25 == 0)
                {




                    if (gewicht == stangegewicht)
                    {
                        erg = "Es werden keine Gewichte benötigt";
                    }



                    gewicht = gewicht - stangegewicht;
                    int test = ((int)gewicht / 40);




                    while (gewicht >= 40)
                    {
                        gewicht = gewicht - 40;
                        zwanzigKGPlatte += 2;
                    }
                    while (gewicht >= 20)
                    {
                        gewicht = gewicht - 20;
                        zehnKGPlatte += 2;
                    }
                    while (gewicht >= 10)
                    {
                        gewicht = gewicht - 10;
                        fuenfKGPlatte += 2;
                    }
                    while (gewicht >= 5)
                    {
                        gewicht = gewicht - 5;
                        zweikommafuenfKGPlatte += 2;
                    }
                    while (gewicht >= 2.5)
                    {
                        gewicht = gewicht - 2.5;
                        einskommazweifuenfKGPlatte += 2;
                    }



                    erg = zwanzigKGPlatte + "," + zehnKGPlatte + "," + fuenfKGPlatte + "," + zweikommafuenfKGPlatte + "," + einskommazweifuenfKGPlatte;



                }
                else erg = "Bitte nur Zahlen die durch 1,25Kg Platten erreicht werden können";

            }
            else erg = "Bitte gebe nur Zahl mit den Endungen ,0 oder ,5 an";




            return erg;
        }
    }
}
