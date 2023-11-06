using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    internal class AnimalManager
    {
        public Dictionary<int, Animals> animalsDic = new Dictionary<int, Animals>();
        public Dictionary<int, Animals> animalsNotInBuilding = new Dictionary<int, Animals>();
        public CropsManager cropsManager;
        public BuildingManager buildingManager;
        public FarmBuilding farmBuilding;
        public WorkerManager workerManager;
        

        public AnimalManager()
        {
            Animals cow = new Animals("Cow","Grass");
            animalsDic.Add(cow.Id, cow);
            animalsNotInBuilding.Add(cow.Id, cow);
            Animals pig = new Animals("Pig", "Carrot");
            animalsDic.Add(pig.Id, pig);
            animalsNotInBuilding.Add(pig.Id , pig);
            Animals chicken = new Animals("Chicken", "Corn");
            animalsDic.Add(chicken.Id, chicken);
            animalsNotInBuilding.Add(chicken.Id, chicken);
            Animals horse = new Animals("Horse", "Hay");
            animalsDic.Add(horse.Id, horse);
            animalsNotInBuilding.Add (horse.Id , horse);
            Animals sheep = new Animals("Sheep", "Grass");
            animalsDic.Add(sheep.Id, sheep);
            animalsNotInBuilding.Add(sheep.Id , sheep);           
        }

        private void AddAnimal(Dictionary<int, FarmBuilding> farm)
        {
            try
            {
                Console.WriteLine("What animal spicie would you like to add?");
                string spicie = Console.ReadLine();
                if (spicie == "" || spicie == " ")
                {
                    Console.WriteLine("The animal must have a name!");
                    Console.WriteLine("Press ENTER to continue....");
                    Console.ReadKey();
                    return;
                }
                foreach (Animals animal in animalsDic.Values)
                {
                    if (spicie == animal.Species)
                    {
                        Console.WriteLine("This animal already exists!");
                        Console.WriteLine("Press ENTER to continue....");
                        Console.ReadKey();
                        return;
                    }
                }

                foreach (Animals animals in animalsDic.Values)
                {
                    if (spicie != animals.Species)
                    {
                        Console.WriteLine("What kind of crops does the animal eat?");
                        string crops = Console.ReadLine();
                        if (crops == "" || crops == " ")
                        {
                            Console.WriteLine("The crop must have a crop type!");
                            Console.WriteLine("Press ENTER to continue....");
                            Console.ReadKey();
                            return;
                        }
                        Animals animal = new Animals(spicie, crops);
                        animalsDic.Add(animal.Id, animal);
                        Animals chosenAnimal = animalsDic[animal.Id];
                        Console.WriteLine("What building would you like to add it to? Choose by ID");                        
                        foreach (FarmBuilding farmBuilding in buildingManager.buildings.Values)
                        {
                            farmBuilding.GetDescription();
                        }
                        try
                        {
                            int buildingId = int.Parse(Console.ReadLine());
                            if (!farm.ContainsKey(buildingId))
                            {
                                Console.WriteLine("There is no such building");
                                Console.WriteLine("Press ENTER to continue..");
                                Console.ReadKey();
                                return;
                            }

                            FarmBuilding farmBuilding = farm[buildingId];
                            farmBuilding.AnimalInBuilding(chosenAnimal);
                            Console.WriteLine(spicie + " was sucessfully added to " + farmBuilding.Name);
                            Console.WriteLine("Press ENTER to continue....");
                            Console.ReadKey();
                        }

                        catch
                        {
                            Console.WriteLine("Something went wrong");
                            Console.WriteLine("Press ENTER to continue..");
                            Console.ReadKey();
                        }                                             
                    }
                }
            }

            catch
            {
                Console.WriteLine("Something went wrong");
                Console.WriteLine("Press ENTER to continue..");
                Console.ReadKey();
            }
        }

        private void FeedAnimal()
        {
            Animals animals = GetAnimalById();
            if (animals == null) 
            {
                Console.WriteLine("There are no such animal");
                Console.WriteLine("Press ENTER to continue..");
                Console.ReadKey();
                return;
            }
           
            Console.WriteLine("What would you like to give the animal?");
            Crops crops = cropsManager.GetCropById();
            if (crops == null) 
            {
                Console.WriteLine("There are no such crop");
                Console.WriteLine("Press ENTER to continue..");
                Console.ReadKey();
                return;
            }
            if(animals.CropTypes != crops.CropType)
            {
                Console.WriteLine("The animal wont eat this!");
                Console.WriteLine("Press ENTER to continue..");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine("How many " + crops.CropType + " would you like to feed the animal?");
            int cropsAmount = int.Parse(Console.ReadLine());
            if (crops.Quantity < cropsAmount)
            {
                Console.WriteLine("There is not enough food!");
                Console.WriteLine("Press ENTER to continue..");
                Console.ReadKey();
                return;
            }

            Worker worker = workerManager.GetWorkerById();   
            if (worker == null)
            {
                Console.WriteLine("There are no such worker");
                Console.WriteLine("Press ENTER to continue..");
                Console.ReadKey();
                return;
            }
           
            if (worker.AnimalSpeciality == animals.Species || worker.CropSpeciality == crops.CropType)
            {
                bool succesful = crops.GetCrop(cropsAmount);
                if (succesful == true)
                {                       
                    Console.WriteLine("Feed the animal with " + crops.CropType);
                    Console.WriteLine("The worker specialize in this animal or crop.");
                    Console.WriteLine("Now the animal is happy!");
                    Console.WriteLine("Press ENTER to continue..");
                    Console.ReadKey();
                }
                
            }
            else if (worker.AnimalSpeciality != animals.Species)
            {
                bool succesful = crops.GetCrop(cropsAmount);
                if (succesful == true)
                {
                    Console.WriteLine("Feed the animal with " + crops.CropType);
                    Console.WriteLine("Press ENTER to continue..");
                    Console.ReadKey();
                } 
                
            }
            else
            {
                Console.WriteLine("Not enough food.");
                Console.WriteLine("Press ENTER to continue..");
                Console.ReadKey();
            }
        }

        private Animals GetAnimalById()
        {
            Console.WriteLine("Which animal? Choose by ID.");
            foreach (Animals animal in animalsDic.Values)
            {
                animal.GetDescription();
            }
            string idToGet = Console.ReadLine();
            try
            {
                int id = Convert.ToInt32(idToGet);
                foreach (Animals animals in animalsDic.Values)
                {
                    if (animals.Id == id)
                    {
                        return animals;
                    }
                }
             
            }
            catch
            {
                Console.WriteLine("Write numbers next time.");
                Console.WriteLine("Press ENTER to continue..");
                Console.ReadKey();
            }
            return null;
        }

        public Dictionary<int, Animals> GetAnimals()
        {
            return animalsDic;
                
        }

        public Dictionary<int, Animals> GetAnimalsWithoutBuildings()
        {
            return animalsNotInBuilding;
        }

        private void RemoveAnimal()
        {
            foreach (Animals animal in animalsDic.Values)
            {
                animal.GetDescription();
            }
            Console.WriteLine("Select which animal to remove. Select by ID.");
            try
            {
                int id = int.Parse(Console.ReadLine());
                if (animalsDic.ContainsKey(id))
                {
                    Animals animals = animalsDic[id];
                    Console.WriteLine("Animal " + id + " " + animals.Species + " has been removed.");
                    animalsDic.Remove(id);
                    Console.WriteLine("Press ENTER to continue..");
                    Console.ReadKey();
                }

                else
                {
                    Console.WriteLine("There is no animal with that ID.");
                    Console.WriteLine("Press ENTER to continue..");
                    Console.ReadKey();
                }
            }

            catch
            {
                Console.WriteLine("Something went wrong");
                Console.WriteLine("Press ENTER to continue..");
                Console.ReadKey();
            }
        }

        private void ViewAnimals()
        {
            foreach (Animals animal in animalsDic.Values)
            {
                animal.GetDescription();
            }
            Console.WriteLine("Press ENTER to continue");
            Console.ReadKey();
        }

        public void ManageAnimals(Dictionary<int, FarmBuilding> farm)
        {
                string[] animalOptions = new string[] { "Feed animals\t", "Remove animal\t", "Add animal\t", "List Animals\t", "Back to main menu\t" };
                int animalSelect = 0;
            

            while (true)
                {
                Console.Clear();
                    if (animalSelect == 0)
                    {
                        Console.WriteLine("Here you can manage the animals!");
                        Console.WriteLine("Choose what you would like to do");
                        Console.WriteLine(animalOptions[0] + "<----");
                        Console.WriteLine(animalOptions[1]);
                        Console.WriteLine(animalOptions[2]);
                        Console.WriteLine(animalOptions[3]);
                        Console.WriteLine(animalOptions[4]);
                    }
                    else if (animalSelect == 1)
                    {
                        Console.WriteLine("Here you can manage the animals!");
                        Console.WriteLine("Choose what you would like to do");
                        Console.WriteLine(animalOptions[0]);
                        Console.WriteLine(animalOptions[1] + "<----");
                        Console.WriteLine(animalOptions[2]);
                        Console.WriteLine(animalOptions[3]);
                        Console.WriteLine(animalOptions[4]);
                    }
                    else if (animalSelect == 2)
                    {
                        Console.WriteLine("Here you can manage the animals!");
                        Console.WriteLine("Choose what you would like to do");
                        Console.WriteLine(animalOptions[0]);
                        Console.WriteLine(animalOptions[1]);
                        Console.WriteLine(animalOptions[2] + "<----");
                        Console.WriteLine(animalOptions[3]);
                        Console.WriteLine(animalOptions[4]);
                    }
                    else if (animalSelect == 3)
                    {
                        Console.WriteLine("Here you can manage the animals!");
                        Console.WriteLine("Choose what you would like to do");
                        Console.WriteLine(animalOptions[0]);
                        Console.WriteLine(animalOptions[1]);
                        Console.WriteLine(animalOptions[2]);
                        Console.WriteLine(animalOptions[3] + "<----");
                        Console.WriteLine(animalOptions[4]);
                    }
                    else if (animalSelect == 4)
                    {
                        Console.WriteLine("Here you can manage the animals!");
                        Console.WriteLine("Choose what you would like to do");
                        Console.WriteLine(animalOptions[0]);
                        Console.WriteLine(animalOptions[1]);
                        Console.WriteLine(animalOptions[2]);
                        Console.WriteLine(animalOptions[3]);
                        Console.WriteLine(animalOptions[4] + "<----");
                    }

                    var keyPressed = Console.ReadKey();

                    if (keyPressed.Key == ConsoleKey.DownArrow && animalSelect != animalOptions.Length - 1)
                    {
                        animalSelect++;
                    }
                    else if (keyPressed.Key == ConsoleKey.UpArrow && animalSelect >= 1)
                    {
                        animalSelect--;
                    }
                    else if (keyPressed.Key == ConsoleKey.Enter)
                    {

                        switch (animalSelect)
                        {
                            case 0:
                                FeedAnimal();
                                break;
                            case 1:
                                RemoveAnimal();
                                break;
                            case 2:
                                AddAnimal(farm);
                                break;
                            case 3:
                                ViewAnimals();
                                break;
                            case 4:

                                return;

                        }
                    }
                }
            }
    }
}


