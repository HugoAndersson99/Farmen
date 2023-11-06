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
        public double Quantity { get; set; }
        
        public Crops (string name, double quantity) :base(name)
        { 
            
            CropType = name;
            Quantity = quantity;
        }

        public bool GetCrop(int Amount)
        {
            if (Amount > Quantity)
            {
                return false;
            }
            Quantity -= Amount;
            return true;
        }

        public override void GetDescription()
        {
            string completeString = "Crop ID: " + Id + " | Crop type: " + CropType + " | Quantity: " + Quantity;
            Console.WriteLine(completeString);

        }

    }
}
