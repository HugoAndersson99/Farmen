using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Farmen
{
    internal class Crops : Entity
    {
        public string CropType {  get; set; }
        public int Quantity { get; set; }
        
        public Crops (string cropType, int quantity)
        { 
            Id = nextId++;
            CropType = cropType;
            Quantity = quantity;
        }

        public void CropsInfo()
        {
            string cropsInfo = "Crop id: " + Id + " Crop type: " + CropType + " Crop quantity: " + Quantity;
            Console.WriteLine(cropsInfo);
        }

    }
}
