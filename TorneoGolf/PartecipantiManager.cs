using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TorneoGolf.Partecipante;

namespace TorneoGolf
{
    class PartecipantiManager
    {
        public static PartecipantiRepository partecipantiRepository = new PartecipantiRepository();


        internal static void ShowPartecipanti()
        {
            List<Partecipante> Partecipante = PartecipantiRepository.Fetch();
            foreach (var partecipante in Partecipante)
            {
                Console.WriteLine(partecipante.Print());
            } 

        }
        internal static Partecipante EditPartecipanti()
        {
            List<Partecipante> partecipante = PartecipantiRepository.Fetch();


            bool isInt;
            int partecipanteScelto;
            do
            {
                Console.WriteLine("Quale partecipante vuoi modificare?");

                isInt = int.TryParse(Console.ReadLine(), out partecipanteScelto);

            } while (!isInt || partecipanteScelto <= 0 || partecipanteScelto > partecipante.Count);

            return partecipante.ElementAt(partecipanteScelto - 1);
        }

        
        internal static void NuovoPartecipante()
        {
 
             Console.WriteLine("Inserisci nuovo partecipante"); 

            Partecipante partecipante = ChiediPartecipante();
            Partecipante partecipanti = new Partecipante();

         }

        private static Partecipante  ChiediPartecipante()
        {
            Partecipante partecipanti = new Partecipante();

            Console.WriteLine("Inserisci il Nome del Nuovo Partecipante");
            Partecipante.Nome = Console.ReadLine();

            Console.WriteLine("Inserisci il Cognome  del Nuovo Partecipante");
            Partecipante.Cognome = Console.ReadLine();


            Console.WriteLine("Inserisci la data di Nascita del Nuovo Partecipante");
            DateTime datanascita = new DateTime();
            while(!DateTime.TryParse(Console.ReadLine(), out datanascita))
            { Console.WriteLine("ritenta"); 
            }
            return partecipanti;
        }


        internal static void RemovePartecipanti()
        {
            int idPartecipante;
            bool isInt;

            do
            {

                isInt = int.TryParse(Console.ReadLine(), out idPartecipante);

            } while (!isInt || idPartecipante >= 0 );

            
                    Partecipante partecipanti = ScegliPartecipante();
                    PartecipantiRepository.Delete(partecipanti);
               
            }

        private static Partecipante ScegliPartecipante()
        {
            List<Partecipante> partecipanti = PartecipantiRepository.Fetch();

            bool isInt;
            int PartecipanteScelto;
            do
            {
                Console.WriteLine("Inserisci l'id del Partecipante da rimuovere");

                isInt = int.TryParse(Console.ReadLine(), out PartecipanteScelto);

            } while (!isInt || PartecipanteScelto <= 0 || PartecipanteScelto > partecipanti.Count);

            return partecipanti.ElementAt(PartecipanteScelto - 1);
        }

        internal static void FilterTesserati()
        {

            List<Partecipante> partecipanti = PartecipantiRepository.Fetch();
            List<Partecipante> partecipantiTesserati = partecipanti.Where(p => p.Tesserato == true).ToList();
           
            foreach(var Partecipante in partecipanti){
                Console.WriteLine(partecipantiTesserati);
            }
         }

        internal static void ViewPartecipanti()
        {
            Partecipante partecipanti = ChiediPartecipante();


        }

        internal static void AddPartecipanti()
        {
            throw new NotImplementedException();
        }

        }

        }
    }
