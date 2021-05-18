using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEonix.Class
{
    public class Dresseur
    {
        public List<Singe> singes { get; set; }

        public Dresseur()
        {
            this.singes = new List<Singe>();
        }
        public void AddNewSinge(Singe singe)
        {
            this.singes.Add(singe);
        }
        public void ExecuteAllTours()
        {
            singes.ForEach(singe => {
                singe.ExecuteAllTour();
            });
        }
    }
}
