using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoGolf
{
    class PartecipantiListRepository: IPartecipantiDbManager
    {

        public static List<Partecipante> partecipanti = new List<Partecipante>
        {
            new Partecipante("Mario", "Rossi", Sesso.Maschio, "1956/02/20", true, 1),
            new Partecipante("Carla", "Bruno", Sesso.Femmina, "1987-12-01", false, 2),
            new Partecipante("Andrea", "Rossi", Sesso.NonDichiarato, "1996-03-28", true, 3),
        };

      
        public List<Partecipante> Fetch()
        {
            return partecipanti;
        }
    }
