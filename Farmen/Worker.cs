using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    internal class Worker : Entity
    {
        
        public string AnimalSpeciality { get; set; }
        public string CropSpeciality { get; set; }
        
        public Worker(string name, string animalSpeciality, string cropSpeciality) : base(name)          
        {
            
            AnimalSpeciality = animalSpeciality;
            CropSpeciality = cropSpeciality;
        }

        public override void GetDescription()
        {
            string completeString = "Worker " + Id + " " + Name + " | Animal Speciality: " + AnimalSpeciality + " | Crop Speciality: " + CropSpeciality;
            Console.WriteLine(completeString);
        }
    }
}
