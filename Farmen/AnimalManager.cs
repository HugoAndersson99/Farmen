using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    internal class AnimalManager
    {
        List<Animals> animalsList = new List<Animals>();

        public AnimalManager()
        {
            animalsList.Add(new Animals("Cow", "Grass"));
            animalsList.Add(new Animals("Pig", "Carrot"));
            animalsList.Add(new Animals("Chicken", "Corn"));
            animalsList.Add(new Animals("Horse", "Hay"));
            animalsList.Add(new Animals("Sheep", "Grass"));
        }

        private void AddAnimal()
        {
            try
            {
                Console.WriteLine("What animals spice would you like to add?");
                string spice = Console.ReadLine();

                Console.WriteLine("What kind of crops does the animal eat?");
                string crops = Console.ReadLine();

                animalsList.Add(new Animals(spice, crops));
                Console.WriteLine("Animal was sucessfully added. ");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void RemoveAnimal()
        {
            Console.WriteLine("This is all of our animals.");
            foreach (Animals animal in animalsList)
            {
                animal.AnimalsInfo();
            }

            Console.WriteLine("Which animal would you like to remove?");
            Console.WriteLine("Select id: ");
            int choice;

            try
            {
                choice = int.Parse(Console.ReadLine());
                    foreach (Animals animal in animalsList)
                {
                    if (choice == animal.Id)
                    {
                        animalsList.Remove(animal);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

           

        }

        public void ViewAnimals()
        {
            foreach (Animals animals in animalsList)
            {
                animals.AnimalsInfo();
            }
            Console.WriteLine("Press ENTER to go back: ");
            Console.ReadKey();
        }

        public void ManageAnimals()
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

                            break;
                        case 1:
                            RemoveAnimal();
                            break;
                        case 2:
                            AddAnimal();
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
