using ConsoleAppEonix.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEonix.Class
{
    public class Spectateur
    {
        public void Reaction(Tour tour)
        {
            Console.WriteLine("Spectateur {0} pendant le tour {1} du singe"
                , tour.Type == TourType.Acrobatie ? "applaudit" : "danse"
                , tour.Type == TourType.Acrobatie ? "d'accrobatie" : "de musique");
        }
    }
}
