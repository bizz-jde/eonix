using ConsoleAppEonix.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEonix.Class
{
    public class Tour
    {
        public string Nom { get; set; }
        public TourType Type { get; set; }

        public Tour(string Nom, TourType Type)
        {
            this.Nom = Nom;
            this.Type = Type;
            //switch (Type)
            //{
            //    case TourType.Acrobatie:
            //        this.Nom = "Tour d'acrobatie";
            //        break;
            //    case TourType.Musique:
            //        this.Nom = "Tour de musique";
            //        break;
            //}
        }
    }
}
