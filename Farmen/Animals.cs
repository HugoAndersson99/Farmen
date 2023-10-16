using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    internal class Animals : Entity
    {
        public string Species { get; set; }
        public string CropTypes { get; set; }

        public Animals(string species, string croptypes)
        {
            Id = nextId;
            Species = species;
            CropTypes = croptypes;
        }

        public void AnimalsInfo()
        {
            string AnimalsInfo = "Animal Id: " + Id + "Specie: " + Species + " Crop type: " + CropTypes;
            Console.WriteLine(AnimalsInfo);
        }
    }

}
