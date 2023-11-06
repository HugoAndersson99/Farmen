using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    internal class FarmBuilding : Entity
    {
        public List<Animals> animalsInBuilding = new List<Animals>();
       
        private int Capacity { get; set; }
        public int Count { get; set; }

        public FarmBuilding(string name, int capacity) :base (name)
        {           
            Capacity = capacity;   
        }

        public override void GetDescription()
        {
            string completeString = "Building ID: " + Id + ". Name: " + Name;
            Console.WriteLine(completeString);
        }

        public void AnimalInBuilding(Animals animal)
        {
            if (Count < Capacity)
            {
                animalsInBuilding.Add(animal);
                Count++;
            }
            else if (Count >= Capacity)
            {
                Console.WriteLine("The building is already full!");
                Console.WriteLine("Press ENTER to to go back: ");
                Console.ReadKey();
            }
        }

        public void RemoveAnimalFromBuilding(Animals animal)
        {
            animalsInBuilding.Remove(animal);
        }

        public void ListAnimalsInBuildings()
        {
            foreach(Animals animals in animalsInBuilding)
            {
                Console.WriteLine("Animal " + animals.Id + " " + animals.Species + " is in building " + Name);
            }
        }
    }
}
