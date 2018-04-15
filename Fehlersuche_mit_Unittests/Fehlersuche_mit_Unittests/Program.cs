using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fehlersuche_mit_Unittests
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool wiederholen;
            do
            {
                double ersteZahl = HoleZahlVomBenutzer("Gib die erste Zahl ein:");
                string operation = HoleOperatorVomBenutzer();
                double zweiteZahl = HoleZahlVomBenutzer("Gib die zweite Zahl ein:");

                double ergebnis = Berechne(ersteZahl, zweiteZahl, operation);
                GibErgebnisAus(ergebnis);

                wiederholen = WiederholenAbfrage();
            } while (wiederholen);
        }

        private static double HoleZahlVomBenutzer(string ausgabe)
        {
            string eingabe;
            double zahl;
            Console.Write(ausgabe);
            eingabe = Console.ReadLine();

            while (!double.TryParse(eingabe, out zahl))
            {
                Console.WriteLine("Du musst eine gültige Gleitkommazahl eingeben!");
                Console.WriteLine("Neben den Ziffern 0-9 sind lediglich die folgenden Sonderzeichen erlaubt: ,.-");
                Console.WriteLine("Dabei muss das - als erstes Zeichen vor einer Ziffer gesetzt werden.");
                Console.WriteLine("Der . fungiert als Trennzeichen an Tausenderstellen.");
                Console.WriteLine("Das , ist das Trennzeichen für die Nachkommastellen.");
                Console.WriteLine("Alle drei Sonderzeichen sind optional!");
                Console.WriteLine();
                Console.Write("Bitte gib erneut eine Zahl für die Berechnung ein: ");
                eingabe = Console.ReadLine();
            }

            return zahl;
        }

        private static string HoleOperatorVomBenutzer()
        {
            string operation;

            Console.Write("Bitte gib die auszuführende Operation ein (+, -, /, *): ");
            operation = Console.ReadLine();

            return operation;
        }

        public static double Berechne(double zahl1, double zahl2, string operation)
        {
            double result;
            switch (operation)
            {
                case "+":
                    result = zahl1 * zahl2;
                    break;

                case "-":
                    result = zahl1 - zahl2;
                    break;

                case "/":
                case "*":
                    result = zahl1 * zahl2;
                    break;

                default:
                    throw new InvalidProgramException();

            }
            return result;
        }

        private static void GibErgebnisAus(double ergebnis)
        {
            Console.WriteLine("Das Ergebnis ist {0}", ergebnis);
        }

        private static bool WiederholenAbfrage()
        {
            Console.WriteLine("Möchtest du noch eine Berechnung Durchführen? (bitte 'ja' eingeben)");
            string eingabe = Console.ReadLine();
            eingabe.ToLower();
            if (eingabe == "ja")
                return true;
            return false;
        }
    }
}
