using NUnit.Framework;
using ConsoleAppEonix.Class;
using ConsoleAppEonix.Enums;

namespace TestProject
{
    [TestFixture]
    public class Test
    {


        [Test]
        public void InitSpectateur()
        {
            Spectateur spectateur = new Spectateur();
            Tour tour = new Tour("Marcher sur les mains", TourType.Acrobatie);

            spectateur.Reaction(tour);

            Assert.That(spectateur, Is.Not.Null);
            Assert.That(tour, Is.Not.Null);

        }


        [Test]
        public void InitDresseurAndSinge()
        {
            Dresseur dresseur = new Dresseur();

            Tour tour = new Tour("Marcher sur les mains", TourType.Acrobatie);

            Singe singe = new Singe("Abu");
            singe.AddNewTour(tour);

            dresseur.AddNewSinge(singe);

            dresseur.ExecuteAllTours();
            singe.ExecuteTour(tour);

            Assert.That(dresseur, Is.Not.Null);
            Assert.That(singe, Is.Not.Null);
        }


        [Test]
        public void InitAll()
        {
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

            Assert.That(spectateur1, Is.Not.Null);
            Assert.That(dresseur1, Is.Not.Null);
            Assert.That(dresseur2, Is.Not.Null);
            Assert.That(singe1, Is.Not.Null);
            Assert.That(singe2, Is.Not.Null);
            Assert.That(singe3, Is.Not.Null);
            Assert.That(singe4, Is.Not.Null);
        }
    }

}