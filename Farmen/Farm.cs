using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    internal class Farm
    {
        CropsManager cropsManager = new CropsManager();
        AnimalManager animalManager = new AnimalManager();
        BuildingManager buildingManager = new BuildingManager();
        WorkerManager workerManager = new WorkerManager();

        public Farm()
        {
            animalManager.buildingManager = buildingManager;
            animalManager.workerManager = workerManager;
            cropsManager.workerManager = workerManager;    
            buildingManager.animalManager = animalManager;
        }

        public void MainMenu()
        {
            animalManager.cropsManager = cropsManager;
            string[] menuOptions = new string[] { "Manage Animals\t", "Manage Crops\t","Manage Buildings\t","Manage Workers", "Leave\t" };
            int menuSelect = 0;

            while (true)
            {
                Console.Clear();

                if (menuSelect == 0)
                {
                    Console.WriteLine("Hello and welcome to The Farm!");
                    Console.WriteLine("Choose what you would like to do: ");
                    Console.WriteLine(menuOptions[0] + " <---");
                    Console.WriteLine(menuOptions[1]);
                    Console.WriteLine(menuOptions[2]);
                    Console.WriteLine(menuOptions[3]);
                    Console.WriteLine(menuOptions[4]);
                }
                else if (menuSelect == 1)
                {
                    Console.WriteLine("Hello and welcome to The Farm!");
                    Console.WriteLine("Choose what you would like to do: ");
                    Console.WriteLine(menuOptions[0]);
                    Console.WriteLine(menuOptions[1] + " <---");
                    Console.WriteLine(menuOptions[2]);
                    Console.WriteLine(menuOptions[3]);
                    Console.WriteLine(menuOptions[4]);
                }
                else if (menuSelect == 2)
                {
                    Console.WriteLine("Hello and welcome to The Farm!");
                    Console.WriteLine("Choose what you would like to do: ");
                    Console.WriteLine(menuOptions[0]);
                    Console.WriteLine(menuOptions[1]);
                    Console.WriteLine(menuOptions[2] + " <---");
                    Console.WriteLine(menuOptions[3]);
                    Console.WriteLine(menuOptions[4]);
                }
                else if (menuSelect == 3)
                {
                    Console.WriteLine("Hello and welcome to The Farm!");
                    Console.WriteLine("Choose what you would like to do: ");
                    Console.WriteLine(menuOptions[0]);
                    Console.WriteLine(menuOptions[1]);
                    Console.WriteLine(menuOptions[2]);
                    Console.WriteLine(menuOptions[3] + " <---");
                    Console.WriteLine(menuOptions[4]);
                }
                else if (menuSelect == 4)
                {
                    Console.WriteLine("Hello and welcome to The Farm!");
                    Console.WriteLine("Choose what you would like to do: ");
                    Console.WriteLine(menuOptions[0]);
                    Console.WriteLine(menuOptions[1]);
                    Console.WriteLine(menuOptions[2]);
                    Console.WriteLine(menuOptions[3]);
                    Console.WriteLine(menuOptions[4] + " <---");
                }
                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
                {
                    menuSelect++;
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
                {
                    menuSelect--;
                }
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    switch (menuSelect)
                    {
                        case 0:
                            animalManager.ManageAnimals(buildingManager.GetBuilding());
                            break;
                        case 1:
                            cropsManager.ManageCrops(workerManager.GetWorker());                   
                            break;
                        case 2:
                            buildingManager.BuildingMenu(animalManager.GetAnimals(), animalManager.GetAnimalsWithoutBuildings());
                            break;
                        case 3:
                            workerManager.WorkerMenu();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    }
}
