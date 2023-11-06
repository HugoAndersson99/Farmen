using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    internal class CropsManager
    {
        public Dictionary<int, Crops> cropsDic = new Dictionary<int, Crops> ();
        public WorkerManager workerManager;

        public CropsManager()
        {
            Crops grass = new Crops("Grass", 100);
            cropsDic.Add(grass.Id, grass);
            Crops hay = new Crops("Hay", 250);
            cropsDic.Add(hay.Id, hay);
            Crops corn = new Crops("Corn", 100);
            cropsDic.Add(corn.Id, corn);
            Crops carrot = new Crops("Carrot", 80);
            cropsDic.Add(carrot.Id, carrot);

        }

        public Crops GetCropById()
        {
            Console.WriteLine("Which crop? Choose by ID.");
            ViewCrops();
            string idToGet = Console.ReadLine();
            try
            {
                int id = Convert.ToInt32(idToGet);
                foreach (Crops crops in cropsDic.Values)
                {
                    if (crops.Id == id)
                    {
                        return crops;
                    }
                }

            }
            catch
            {
                Console.WriteLine("Write numbers next time.");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey();
            }
            return null;
        }

        private void AddCrop(Dictionary<int, Worker> workers)
        {
            double multiply = 1.5;
            Console.WriteLine("Name the crop type you would like to add.");
            string cropName = Console.ReadLine();
            if (cropName == "" || cropName == " ")
            {
                Console.WriteLine("The crop must have a crop type.");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Enter number of crops you would like to add.");
            try
            {
                int cropQuantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Which worker do you want to add the crop? Choose by ID.");
                foreach (Worker worker in workers.Values)
                {
                    worker.GetDescription();
                }
                int workerId = int.Parse(Console.ReadLine());
                if (!workers.ContainsKey(workerId))
                {
                    Console.WriteLine("There is no such worker");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadKey();
                    return;
                }

                Worker chosenWorker = workers[workerId];
                foreach (Crops crop in cropsDic.Values)
                {
                    if (cropName == crop.CropType)
                    {
                        Console.WriteLine("Adding to already existing crop " + cropName);
                        if (chosenWorker.CropSpeciality == crop.CropType)
                        {
                            double newCropQuantity = (cropQuantity * multiply);
                            crop.Quantity += newCropQuantity;
                            Console.WriteLine("This worker had the crop as its speciality!");
                            Console.WriteLine("Added " + newCropQuantity + " to " + crop.CropType);
                            Console.WriteLine("Press ENTER to continue...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            crop.Quantity += cropQuantity;
                            Console.WriteLine("Added " + cropQuantity + " to " + crop.CropType);
                            Console.WriteLine("Press ENTER to continue...");
                            Console.ReadKey();
                            break;
                        }

                    }
                    else if (cropName != crop.CropType && cropName != "")
                    {
                        Console.WriteLine("Adding new crop " + cropName);
                        Crops crops = new Crops(cropName, cropQuantity);
                        cropsDic.Add(crops.Id, crops);
                        if (crops.CropType == chosenWorker.CropSpeciality)
                        {
                            double newCropQuantity = (cropQuantity * multiply);
                            crops.Quantity = newCropQuantity;
                            Console.WriteLine("This worker had the crop as its speciality!");
                            Console.WriteLine("Added " + newCropQuantity + " to " + crops.CropType);
                            Console.WriteLine("Press ENTER to continue...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {

                            Console.WriteLine("Added " + cropQuantity + " to " + crops.CropType + ".");
                            Console.WriteLine("Press ENTER to continue...");
                            Console.ReadKey();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The crop must have a name or amount.");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadKey();
                        break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey();
            }

        }

        private void ViewCrops()
        {
            foreach (Crops crops in cropsDic.Values)
            {
                crops.GetDescription();
            }
        }

        private void RemoveCrop()
        {
            foreach (Crops crops in cropsDic.Values)
            {
                crops.GetDescription();
            }

            Console.WriteLine("Select the crop you would like to remove. Select by ID.");

            try 
            {
                int id = int.Parse(Console.ReadLine());
                if (cropsDic.ContainsKey(id)) 
                {
                    Crops crops = cropsDic[id];
                    Console.WriteLine("Crop " + id + " " + crops.CropType + " has successfully been removed.");
                    cropsDic.Remove(id);
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadKey();
                }
            }

            catch 
            {
                Console.WriteLine("Something went wrong.");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey();
            }          
        }

        public void ManageCrops(Dictionary<int, Worker> work)
        {
            
            string[] cropsOptions = new string[] { "View crops\t", "Add crop\t", "Remove crop\t",  "Back to main menu\t" };
            int menuSelect = 0;

            while (true)
            { 
                Console.Clear();
                if (menuSelect == 0)
                {
                    Console.WriteLine("Here you can manage the crops!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(cropsOptions[0] + " <---");
                    Console.WriteLine(cropsOptions[1]);
                    Console.WriteLine(cropsOptions[2]);
                    Console.WriteLine(cropsOptions[3]);
                    
                }
                else if (menuSelect == 1)
                {
                    Console.WriteLine("Here you can manage the crops!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(cropsOptions[0]);
                    Console.WriteLine(cropsOptions[1] + " <---");
                    Console.WriteLine(cropsOptions[2]);
                    Console.WriteLine(cropsOptions[3]);
                    
                }
                else if (menuSelect == 2)
                {
                    Console.WriteLine("Here you can manage the crops!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(cropsOptions[0]);
                    Console.WriteLine(cropsOptions[1]);
                    Console.WriteLine(cropsOptions[2] + " <---");
                    Console.WriteLine(cropsOptions[3]);
                    
                }
                else if (menuSelect == 3)
                {
                    Console.WriteLine("Here you can manage the crops!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(cropsOptions[0]);
                    Console.WriteLine(cropsOptions[1]);
                    Console.WriteLine(cropsOptions[2]);
                    Console.WriteLine(cropsOptions[3] + " <---");
                    
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
                            Console.WriteLine("Press ENTER to continue...");
                            Console.ReadKey();
                            break;
                        case 1:
                            AddCrop(work);
                            break;
                        case 2:
                           RemoveCrop();
                            break;
                        case 3:
                            return;
                    }
                }
            }
        }
    }
}
