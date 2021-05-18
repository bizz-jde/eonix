using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEonix.Class
{
    public class Singe
    {
        public string nom { get; set; }
        public List<Tour> tours { get; set; }

        public Singe(string nom)
        {
            this.nom = nom;
            this.tours = new List<Tour>();
            //this.tours.Add(new Tour(Enums.TourType.Acrobatie));
            //this.tours.Add(new Tour(Enums.TourType.Musique));
        }

        public void AddNewTour(Tour Tour)
        {
            this.tours.Add(Tour);
        }

        public void ExecuteAllTour()
        {
            Console.WriteLine("Le singe {0} doit executer {1} tours!", this.nom, this.tours.Count.ToString());
            int index = 1;
            this.tours.ForEach(tour =>
            {
                Console.WriteLine("Le singe {0} exécute son tour N° {1} : c'est un {2}"
                    , this.nom
                    , index
                    , tour.Nom);
                index++;
            });
        }
        public void ExecuteTour(Tour tour)
        {
            Console.WriteLine("Le singe {0} exécute son tour {1}"
                                , this.nom
                                , tour.Nom);
        }
    }
}
