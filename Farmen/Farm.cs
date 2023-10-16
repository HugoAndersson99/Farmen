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
        public void MainMenu()
        {
            string[] menuOptions = new string[] { "Manage animals\t", "Manage Crops\t", "Leave\t" };
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
                }
                else if (menuSelect == 1)
                {
                    Console.WriteLine("Hello and welcome to The Farm!");
                    Console.WriteLine("Choose what you would like to do: ");
                    Console.WriteLine(menuOptions[0]);
                    Console.WriteLine(menuOptions[1] + " <---");
                    Console.WriteLine(menuOptions[2]);
                }
                else if (menuSelect == 2)
                {
                    Console.WriteLine("Hello and welcome to The Farm!");
                    Console.WriteLine("Choose what you would like to do: ");
                    Console.WriteLine(menuOptions[0]);
                    Console.WriteLine(menuOptions[1]);
                    Console.WriteLine(menuOptions[2] + " <---");
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
                            animalManager.ManageAnimals();
                            break;
                        case 1:
                            cropsManager.ManageCrops();
                            break;
                        case 2:
                            Environment.Exit(0);
                            break;

                    }
                }
            }

        }
    }
}
