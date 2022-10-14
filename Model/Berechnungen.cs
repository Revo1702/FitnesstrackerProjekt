﻿using System;
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

        public string Kalorienrechner()
        {
            Console.Write("Dein alter: ");
            double alter = Convert.ToDouble(Console.ReadLine());



            Console.Write("Dein Gewicht: ");
            double gewicht = Convert.ToDouble(Console.ReadLine());



            Console.Write("Deine Größe: ");
            double groesse = Convert.ToDouble(Console.ReadLine());



            double grundumsatz = Math.Round((10 * gewicht) + (6.25 * groesse) - (5 * alter) + 5, 2);



            double[] palwerte = new double[6];



            palwerte[0] = 0.95;  // schlafen
            palwerte[1] = 1.2;   // liegen
            palwerte[2] = 1.5;   //sitzen
            palwerte[3] = 1.7;   // stehen
            palwerte[4] = 1.9;   //gehen
            palwerte[5] = 2.4;   //körperliche Ansträngungen




            double arbeitsumsatz = Math.Round(grundumsatz * palwerte[4], 2);



            double gesamtumsatz = Math.Round(grundumsatz + arbeitsumsatz, 2);



            string returnString = "dein täglicher Kalorienbedarf beträgt: " + gesamtumsatz;
            return returnString;
        }

        public string BMIRechner(double weight, double height)
        {
            double bmi = weight / (height * height);



            Console.WriteLine("Dein BMI ist: " + bmi);
            Console.Write("Klassifizierung: ");
            string returnString = "";


            if (bmi < 18.5)
                returnString = "Untergewicht";
            else if (bmi < 25)
                returnString = "Normalgewicht";
            else if (bmi < 30)
                returnString = "Übergewicht";
            else if (bmi < 35)
                returnString = "Adipositas Grad 1";
            else if (bmi < 40)
                returnString = "Adipositas Grad 2";
            else
                returnString = "Adipositas Grad 3";

            return returnString;
        }
    }
}
