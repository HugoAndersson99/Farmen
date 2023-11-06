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
        
        
        public Animals(string name, string croptypes) :base(name)
        {
            Species = name;
            CropTypes = croptypes;
        }

        public override void GetDescription()
        {
            string completeString = "Animal Id: " + Id + " | Specie: " + Species + " | Crop type: " + CropTypes;
            Console.WriteLine(completeString);
        }
    }
}
