using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    internal class CropsManager
    {
        List<Crops> cropsList = new List<Crops>();

        public CropsManager()
        {
            cropsList.Add(new Crops("Grass", 100));
            cropsList.Add(new Crops("Hay", 250));
            cropsList.Add(new Crops("Corn", 100));
            cropsList.Add(new Crops("Carrot", 80));
              
        }



        private void AddCrop()
        {
            try
            {
                Console.WriteLine("What crop type would you like to add?");
                string cropType = Console.ReadLine();
                foreach (Crops crops in cropsList)
                {
                    if (cropType == crops.CropType)
                    {
                        Console.WriteLine("How many crops would you like to add?");
                        int input = int.Parse(Console.ReadLine());
                        crops.Quantity += input;
                        Console.WriteLine("Crops quantity: " + crops.Quantity);
                    }
                    else if (cropType != crops.CropType)
                    {
                        Console.WriteLine("How many crops would like like to add of this kind?");
                        int input = int.Parse(Console.ReadLine());
                        cropsList.Add(new Crops(cropType, input));
                        Console.WriteLine(input + " Crops was sucessfully added of the kind " + cropType);
                    }
                }
               

                
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ViewCrops()
        {
            foreach (Crops crops in cropsList)
            {
                crops.CropsInfo();
            }
        }

        public void RemoveCrop()
        {
            Console.WriteLine("What crop would you like to remove? ");
            
            foreach (Crops crops in cropsList)
            {
                crops.CropsInfo();
            }
            Console.WriteLine("Write the id of the crop you want to remove");
            int id;
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
                foreach (Crops crops in cropsList)
                {
                    if (id == crops.Id)
                    {
                        cropsList.Remove(crops);
                    }
                }
            }
            catch 
            { 
                
            }

                
        }



        public void ManageCrops()
        {
            
            string[] cropsOptions = new string[] { "View crops\t", "Add crop\t", "Remove crop\t", "List crops\t", "Back to main menu\t" };
            int menuSelect = 0;

            while (true)
            {
                if (menuSelect == 0)
                {
                    
                    Console.WriteLine(cropsOptions[0] + " <---");
                    Console.WriteLine(cropsOptions[1]);
                    Console.WriteLine(cropsOptions[2]);
                    Console.WriteLine(cropsOptions[3]);
                    Console.WriteLine(cropsOptions[4]);
                }
                else if (menuSelect == 1)
                {
                    Console.WriteLine(cropsOptions[0]);
                    Console.WriteLine(cropsOptions[1] + " <---");
                    Console.WriteLine(cropsOptions[2]);
                    Console.WriteLine(cropsOptions[3]);
                    Console.WriteLine(cropsOptions[4]);
                }
                else if (menuSelect == 2)
                {
                    Console.WriteLine(cropsOptions[0]);
                    Console.WriteLine(cropsOptions[1]);
                    Console.WriteLine(cropsOptions[2] + " <---");
                    Console.WriteLine(cropsOptions[3]);
                    Console.WriteLine(cropsOptions[4]);
                }
                else if (menuSelect == 3)
                {
                    Console.WriteLine(cropsOptions[0]);
                    Console.WriteLine(cropsOptions[1]);
                    Console.WriteLine(cropsOptions[2]);
                    Console.WriteLine(cropsOptions[3] + " <---");
                    Console.WriteLine(cropsOptions[4]);
                }
                else if (menuSelect == 4)
                {
                    Console.WriteLine(cropsOptions[0]);
                    Console.WriteLine(cropsOptions[1]);
                    Console.WriteLine(cropsOptions[2]);
                    Console.WriteLine(cropsOptions[3]);
                    Console.WriteLine(cropsOptions[4] + " <---");
                }

                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect != cropsOptions.Length - 1)
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
                            ViewCrops();
                            break;
                        case 1:
                            AddCrop();
                            break;
                        case 2:
                           RemoveCrop();
                            break;
                        case 3:
                            ViewCrops();
                            break;
                        case 4:
                            return;
                            break;

                    }
                }


            }
        }
    }
}
