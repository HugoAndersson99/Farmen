using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    internal class BuildingManager
    {
        public List<FarmBuilding> buildingsList = new List<FarmBuilding>();
        public Dictionary<int, FarmBuilding> buildings = new Dictionary<int, FarmBuilding>();
        public AnimalManager animalManager;
        public FarmBuilding farmBuilding;
        
        public BuildingManager()
        {
            FarmBuilding OldBarn = new FarmBuilding("Old Barn", 5);
            buildings.Add(OldBarn.Id, OldBarn);
            FarmBuilding NewBarn = new FarmBuilding("New Barn", 4);
            buildings.Add(NewBarn.Id, NewBarn);
            FarmBuilding OldPasture = new FarmBuilding("Old Pasture", 50);
            buildings.Add(OldPasture.Id, OldPasture);
            FarmBuilding NewStable = new FarmBuilding("New Stable", 4);
            buildings.Add(NewStable.Id, NewStable);

        }
      
        private void ViewBuildings()
        {
            foreach (FarmBuilding farmBuilding in buildings.Values)
            {
                farmBuilding.GetDescription();
            }
            Console.WriteLine("Press ENTER to continue");
            Console.ReadKey();
        }

        public void AnimalsInBuilding()
        {
            foreach (FarmBuilding farmBuilding in buildings.Values)
            {
                farmBuilding.GetDescription();
            }
            Console.WriteLine("Which building? Choose by ID.");
            try
            {       
                int buildingId = int.Parse(Console.ReadLine());
                FarmBuilding farmBuilding = buildings[buildingId];
                if (farmBuilding.animalsInBuilding.Count < 1)
                {
                    Console.WriteLine("There are no animals in this building");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadKey();
                    return;
                }
                if (!buildings.ContainsKey(buildingId))
                {
                    Console.WriteLine("There is no such building.");
                    Console.ReadKey();
                    return;
                }
                
                farmBuilding.ListAnimalsInBuildings();
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
                Console.ReadKey();
            }            
        }
        
        public void AddAnimalToBuilding(Dictionary<int, Animals> animals)
        {
            if (animals.Count < 1)
            {
                Console.WriteLine("There are no animals without buildings!");
                Console.WriteLine("If you would like to move animals use ''Switch animal from building''.");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey();
                return;
            }
            foreach (FarmBuilding farmBuilding in buildings.Values)
            {
                farmBuilding.GetDescription();
            }

            Console.WriteLine("Which building? Give its ID.");
            try
            {
                int buildingId = int.Parse(Console.ReadLine());
                if (!buildings.ContainsKey(buildingId))
                {
                    Console.WriteLine("There is no such building.");
                    Console.ReadKey();
                    return;
                }

                FarmBuilding farmBuilding = buildings[buildingId];
                
                
                Console.WriteLine("Animals currently not in any building: ");
                foreach (Animals animal in animals.Values)
                {
                    animal.GetDescription();
                }
                Console.WriteLine("Which animal? Give their ID.");
                int animalId = int.Parse(Console.ReadLine());
                if (!animals.ContainsKey(animalId))
                {
                    Console.WriteLine("There is no such animal.");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadKey();
                    return;
                }
                
                Animals chosenAnimal = animals[animalId];
                farmBuilding.AnimalInBuilding(chosenAnimal);
                animalManager.animalsNotInBuilding.Remove(animalId);
                Console.WriteLine("Moved animal " + animalId + " to " + farmBuilding.Name);
                Console.WriteLine("Press ENTER to continue..");
                Console.ReadKey();

            }
            catch
            {
                Console.WriteLine("Something went wrong.");
                Console.WriteLine("Press ENTER to continue..");
                Console.ReadKey();
            }
        }
        
        private void AddBuilding()
        {
            Console.WriteLine("What is the name of the Building?");
            string input = Console.ReadLine();
            if (input != "" || input != " ")
            {
                Console.WriteLine("How many animals does the building fit?");
                try
                {
                    int capacity = int.Parse(Console.ReadLine());
                    if (capacity > 0)
                    {
                        FarmBuilding farmBuilding = new FarmBuilding(input, capacity);
                        buildings.Add(farmBuilding.Id, farmBuilding);
                        Console.WriteLine("Building: " + input + " was successfully added.");
                        Console.WriteLine("Press ENTER to continue..");
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.WriteLine("Something went wrong");
                    Console.WriteLine("Press ENTER to continue..");
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                Console.WriteLine("They need a name!");
                Console.WriteLine("Press ENTER to continue..");
                Console.ReadKey();
            }
        }
       
       private void RemoveBuilding()
       {
            foreach (FarmBuilding farmBuilding in buildings.Values)
            {
                farmBuilding.GetDescription();
            }
            Console.WriteLine("What kind of building would you like to remove? Give their ID");
            
            try
            {
                int id = int.Parse(Console.ReadLine());
                if (buildings.ContainsKey(id))
                {
                    FarmBuilding farm = buildings[id];
                    Console.WriteLine("Building " + id + " " + farm.Name + " has been removed.");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadKey();
                    buildings.Remove(id);
                }
                else
                {
                    Console.WriteLine("There is no building with that ID.");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("Please write numbers");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey();
            }
       }


        public Dictionary<int, FarmBuilding> GetBuilding()
        {
            return buildings;
        }

        public void SwitchBuilding(Dictionary<int, Animals> animals) 
        {
            try 
            {
                foreach (FarmBuilding farmBuilding in buildings.Values)
                {
                    farmBuilding.GetDescription();
                }
                Console.WriteLine("Select which building you would like to move the animal from. Choose by ID");
                int id = int.Parse(Console.ReadLine());
                if (!buildings.ContainsKey(id))
                {
                    Console.WriteLine("No such building exists.");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadKey();
                    return;
                }
                FarmBuilding removeBuilding = buildings[id];
                if (removeBuilding.animalsInBuilding.Count < 1)
                {
                    Console.WriteLine("There are no animals in this building.");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadKey();
                    return;
                }

                removeBuilding.ListAnimalsInBuildings();
                Console.WriteLine("Select which animal you would like to move. Select by ID.");
                int chooseAnimal = int.Parse(Console.ReadLine());
                Animals removedAnimal = animals[chooseAnimal];
                if (!removeBuilding.animalsInBuilding.Contains(removedAnimal))
                {
                    Console.WriteLine("This animal does not exist in this building.");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadKey();
                    return;
                }
                
                foreach (FarmBuilding farmBuilding in buildings.Values)
                {
                    farmBuilding.GetDescription();
                }
                Console.WriteLine("Select which building you would like to move " + chooseAnimal + " " + removedAnimal.Name + " to. Select by ID.");
                int chooseBuilding = int.Parse(Console.ReadLine());

                if (!buildings.ContainsKey(chooseBuilding))
                {
                    Console.WriteLine("No building with that ID.");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadKey();
                    return;
                }
                
                removeBuilding.RemoveAnimalFromBuilding(removedAnimal);
                Animals animal = animals[chooseAnimal];
                FarmBuilding building = buildings[chooseBuilding];
                
                building.AnimalInBuilding(animal);

                Console.WriteLine("Successfully moved animal " + animal.Id + " " + animal.Species + " from " + removeBuilding.Name + " to " + building.Name);
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey();
            }

           catch 
            {
               Console.WriteLine("Something went wrong. Please try again.");
               Console.WriteLine("Press ENTER to continue...");
               Console.ReadKey();
            }

        }

        public void BuildingMenu(Dictionary<int, Animals> animals, Dictionary<int, Animals> animals2)
        {
            string[] buildingOptions = new string[] { "View buildings\t", "Add building\t", "Remove building\t","Add animal to building\t", "View animals in buildings\t","Switch animal from building\t", "Back to main menu\t" };
            int buildingSelect = 0;

            while (true)
            {
                Console.Clear();
                if (buildingSelect == 0)
                {
                    Console.WriteLine("Here you can manage the buildings!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(buildingOptions[0] + "<----");
                    Console.WriteLine(buildingOptions[1]);
                    Console.WriteLine(buildingOptions[2]);
                    Console.WriteLine(buildingOptions[3]);
                    Console.WriteLine(buildingOptions[4]);
                    Console.WriteLine(buildingOptions[5]);
                    Console.WriteLine(buildingOptions[6]);

                }
                else if (buildingSelect == 1)
                {
                    Console.WriteLine("Here you can manage the buildings!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(buildingOptions[0]);
                    Console.WriteLine(buildingOptions[1] + "<----");
                    Console.WriteLine(buildingOptions[2]);
                    Console.WriteLine(buildingOptions[3]);
                    Console.WriteLine(buildingOptions[4]);
                    Console.WriteLine(buildingOptions[5]);
                    Console.WriteLine(buildingOptions[6]);

                }
                else if (buildingSelect == 2)
                {
                    Console.WriteLine("Here you can manage the buildings!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(buildingOptions[0]);
                    Console.WriteLine(buildingOptions[1]);
                    Console.WriteLine(buildingOptions[2] + "<----");
                    Console.WriteLine(buildingOptions[3]);
                    Console.WriteLine(buildingOptions[4]);
                    Console.WriteLine(buildingOptions[5]);
                    Console.WriteLine(buildingOptions[6]);

                }
                else if (buildingSelect == 3)
                {
                    Console.WriteLine("Here you can manage the buildings!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(buildingOptions[0]);
                    Console.WriteLine(buildingOptions[1]);
                    Console.WriteLine(buildingOptions[2]);
                    Console.WriteLine(buildingOptions[3] + "<----");
                    Console.WriteLine(buildingOptions[4]);
                    Console.WriteLine(buildingOptions[5]);
                    Console.WriteLine(buildingOptions[6]);

                }
                else if (buildingSelect == 4)
                {
                    Console.WriteLine("Here you can manage the buildings!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(buildingOptions[0]);
                    Console.WriteLine(buildingOptions[1]);
                    Console.WriteLine(buildingOptions[2]);
                    Console.WriteLine(buildingOptions[3]);
                    Console.WriteLine(buildingOptions[4] + "<----");
                    Console.WriteLine(buildingOptions[5]);
                    Console.WriteLine(buildingOptions[6]);
                    

                }
                else if (buildingSelect == 5)
                {
                    Console.WriteLine("Here you can manage the buildings!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(buildingOptions[0]);
                    Console.WriteLine(buildingOptions[1]);
                    Console.WriteLine(buildingOptions[2]);
                    Console.WriteLine(buildingOptions[3]);
                    Console.WriteLine(buildingOptions[4]);
                    Console.WriteLine(buildingOptions[5] + "<----");
                    Console.WriteLine(buildingOptions[6]);
                }
                else if (buildingSelect == 6)
                {
                    Console.WriteLine("Here you can manage the buildings!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(buildingOptions[0]);
                    Console.WriteLine(buildingOptions[1]);
                    Console.WriteLine(buildingOptions[2]);
                    Console.WriteLine(buildingOptions[3]);
                    Console.WriteLine(buildingOptions[4]);
                    Console.WriteLine(buildingOptions[5]);
                    Console.WriteLine(buildingOptions[6] + "<----");
                }

                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && buildingSelect != buildingOptions.Length - 1)
                {
                    buildingSelect++;
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && buildingSelect >= 1)
                {
                    buildingSelect--;
                }
                else if (keyPressed.Key == ConsoleKey.Enter)
                {

                    switch (buildingSelect)
                    {
                        case 0:
                            ViewBuildings();
                            break;
                        case 1:
                            AddBuilding();
                            break;
                        case 2:
                            RemoveBuilding();
                            break;
                        case 3:
                            AddAnimalToBuilding(animals2);
                            break;
                        case 4:
                            AnimalsInBuilding();
                            break;
                        case 5:
                            SwitchBuilding(animals);
                            break;
                        case 6:
                            return;

                    }
                }
            }
        }
    }
}




