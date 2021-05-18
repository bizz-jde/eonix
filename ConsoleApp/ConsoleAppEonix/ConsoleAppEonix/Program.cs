using ConsoleAppEonix.Class;
using ConsoleAppEonix.Enums;
using System;

namespace ConsoleAppEonix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application console Eonix");
            Console.WriteLine("----------------------------------------------");

            #region Class init
            Spectateur spectateur1 = new Spectateur();
            Dresseur dresseur1 = new Dresseur();
            Dresseur dresseur2 = new Dresseur();

            Tour tour1 = new Tour("Marcher sur les mains", TourType.Acrobatie);
            Tour tour2 = new Tour("Fait de la musique", TourType.Musique);

            Singe singe1 = new Singe("Abu");
            singe1.AddNewTour(tour1);
            singe1.AddNewTour(tour2);
            Singe singe2 = new Singe("Cheeta");
            singe2.AddNewTour(tour1);
            singe2.AddNewTour(tour2);
            Singe singe3 = new Singe("King Kong");
            singe3.AddNewTour(tour1);
            singe3.AddNewTour(tour2);
            Singe singe4 = new Singe("Rafiki");
            singe4.AddNewTour(tour1);
            singe4.AddNewTour(tour2);

            dresseur1.AddNewSinge(singe1);
            dresseur1.AddNewSinge(singe2);
            dresseur2.AddNewSinge(singe3);
            dresseur2.AddNewSinge(singe4);
            #endregion

            Console.WriteLine("Un spectateur rencontre 2 dresseurs");

            Console.WriteLine("Le premier dresseur veut montrer les tours de ses singes");
            Console.WriteLine("Voulez-vous les voir?");
            Console.WriteLine("\to - Oui");
            Console.WriteLine("\tn - Non");

            switch (Console.ReadLine())
            {
                case "o":
                    ExecuteTour(dresseur1, spectateur1);
                    break;
                case "n":
                    break;
            }

            Console.WriteLine("Le deuxieme dresseur veut montrer les tours de ses singes");
            Console.WriteLine("Voulez-vous les voir?");
            Console.WriteLine("\to - Oui");
            Console.WriteLine("\tn - Non");

            switch (Console.ReadLine())
            {
                case "o":
                    ExecuteTour(dresseur2, spectateur1);
                    break;
                case "n":
                    break;
            }


        }

        static void ExecuteTour(Dresseur dresseur, Spectateur spectateur)
        {
            dresseur.singes.ForEach(singe =>
            {
                singe.tours.ForEach(tour =>
                {
                    singe.ExecuteTour(tour);
                    spectateur.Reaction(tour);
                });
            });
        }

    }

}
