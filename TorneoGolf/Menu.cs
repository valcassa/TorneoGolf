using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoGolf
{

    class Menu
    {
        internal static void Start()
        {
            bool continuare = true;

            do
            {
                Console.WriteLine("**** TORNEO DI GOLF ****");

                Console.WriteLine("1 - Visualizza tutti gli iscritti");
                Console.WriteLine("2 - Modifica i dati di un iscritto");
                Console.WriteLine("3 - Elimina  un iscritto");
                Console.WriteLine("4 - Inserisci un nuovo iscritto");
                Console.WriteLine("5 - Visualizza un iscritto per Nome Cognome");
                Console.WriteLine("6 - Filtra i tesserati");
                Console.WriteLine("0 - Esci dal programma");
                Console.WriteLine();
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        PartecipantiManager.ShowPartecipanti();
                        break;
                    case "2":
                        PartecipantiManager.EditPartecipanti();
                        break;
                    case "3":
                        PartecipantiManager.RemovePartecipanti();
                        break;
                    case "4":
                        PartecipantiManager.AddPartecipanti();
                        break;
                    case "5":
                        PartecipantiManager.ViewPartecipanti();
                        break;
                    case "6":
                        PartecipantiManager.FilterTesserati();
                        break;
                    case "0":
                        Console.WriteLine("Chiusura del programma in corso");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta errata, ritenta");
                        break;
                }
            } while (continuare);
        }
    }
}