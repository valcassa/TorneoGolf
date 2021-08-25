using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoGolf
{

    public class Partecipante
    {
        public static string Nome { get; set; }
        public static string Cognome { get; set; }
        public enum Sesso { Maschio, Femmina, NonDichiarato }
        public DateTime DataNascita { get; set; }

        public bool Tesserato = false;
        public int IdPartecipante { get; set; }

        public Partecipante(string n, string c, string Sesso, DateTime nascita, bool t, int id)
        {
            Nome = n;
            Cognome = c; 
            DataNascita = nascita;
            Tesserato = t;
            IdPartecipante = id;


        }
         
        public Partecipante()
        {
        }

        public virtual string Print()
        {
            return $"{Nome}, {Cognome}";
        }


        public static InserisciGenere()
        {

            int sesso;
            bool isInt;

            do
            {
                Console.WriteLine("Inserisci il sesso");
                foreach (var genere in Enum.GetValues(typeof(Sesso)))
                {
                    Console.WriteLine($"Premi {(int)genere} per {(Sesso)genere}");
                }



                isInt = int.TryParse(Console.ReadLine(), out sesso);
            } while (!isInt || sesso < 0 || sesso > 2);

            return (Partecipante.Sesso)sesso;

        }
}