using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    internal class WorkerManager
    {
        
        public Dictionary<int, Worker> workerDic = new Dictionary<int, Worker>();

        public WorkerManager()
        {
            Worker bengt = new Worker("Bengt", "Cow", "Hay");
            workerDic.Add(bengt.Id, bengt);
            Worker jacob = new Worker("Jacob", "Horse", "Carrot");
            workerDic.Add(jacob.Id, jacob);
            Worker hanna = new Worker("Hanna", "Pig", "Grass");
            workerDic.Add(hanna.Id, hanna);
            Worker olof = new Worker("Olof", "Chicken", "Corn");
            workerDic.Add(olof.Id, olof);
            Worker lars = new Worker("Lars", "Sheep", "Grass");
            workerDic.Add(lars.Id, lars);           
        }

        private void ViewWorkers()
        {
            foreach (Worker worker in workerDic.Values)
            {
                worker.GetDescription();
            }
            
        }

        private void AddWorker()
        {
            Console.WriteLine("Name the worker you would like to add.");
            string nameWorker = Console.ReadLine();
            Console.WriteLine("Enter which animal " + nameWorker + " specializes in.");
            string animalSpec = Console.ReadLine();
            Console.WriteLine("Enter which crop " + nameWorker + " specializes in.");
            string cropSpec = Console.ReadLine();

            if (nameWorker != "") 
            {
                Worker worker = new Worker(nameWorker, animalSpec, cropSpec);
                workerDic.Add(worker.Id, worker);
                Console.WriteLine(nameWorker + " was successfully added.");
                Console.WriteLine(nameWorker + " specializes in " + animalSpec + " and " + cropSpec + ".");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey();
            }

            else 
            {
                Console.WriteLine("Something went wrong. Try again.");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey();
            }       
        }

        public Worker GetWorkerById()
        {
            Console.WriteLine("Which worker? Choose by ID.");
            ViewWorkers();
            string idToGet = Console.ReadLine();
            try
            {
                int id = Convert.ToInt32(idToGet);
                foreach (Worker worker in workerDic.Values)
                {
                    if (worker.Id == id)
                    {
                        return worker;
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

        private void RemoveWorker()
        {
            ViewWorkers();
            Console.WriteLine("Which worker would you like to remove? Select by ID.");
            try
            {
                int id = int.Parse(Console.ReadLine());
                if (workerDic.ContainsKey(id))
                {
                    Worker worker = workerDic[id];
                    Console.WriteLine("Worker " + id + " " + worker.Name + " has been removed");
                    workerDic.Remove(id);
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadKey();

                }
                else
                {
                    Console.WriteLine("No such worker..");
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

        public Dictionary<int, Worker> GetWorker()
        {
            return workerDic;  
        }

        public void WorkerMenu()
        {

            string[] workerOptions = new string[] { "View workers\t", "Add worker\t", "Remove worker\t", "Back to main menu\t" };
            int workerSelect = 0;

            while (true)
            {
                Console.Clear();
                if (workerSelect == 0)
                {
                    Console.WriteLine("Here you can manage the workers!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(workerOptions[0] + "<----");
                    Console.WriteLine(workerOptions[1]);
                    Console.WriteLine(workerOptions[2]);
                    Console.WriteLine(workerOptions[3]);
                    
                }
                else if (workerSelect == 1)
                {
                    Console.WriteLine("Here you can manage the workers!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(workerOptions[0]);
                    Console.WriteLine(workerOptions[1] + "<----");
                    Console.WriteLine(workerOptions[2]);
                    Console.WriteLine(workerOptions[3]);
                    
                }
                else if (workerSelect == 2)
                {
                    Console.WriteLine("Here you can manage the workers!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(workerOptions[0]);
                    Console.WriteLine(workerOptions[1]);
                    Console.WriteLine(workerOptions[2] + "<----");
                    Console.WriteLine(workerOptions[3]);
                    
                }
                else if (workerSelect == 3)
                {
                    Console.WriteLine("Here you can manage the workers!");
                    Console.WriteLine("Choose what you would like to do");
                    Console.WriteLine(workerOptions[0]);
                    Console.WriteLine(workerOptions[1]);
                    Console.WriteLine(workerOptions[2]);
                    Console.WriteLine(workerOptions[3] + "<----");
                    
                }
                

                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && workerSelect != workerOptions.Length - 1)
                {
                    workerSelect++;
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && workerSelect >= 1)
                {
                    workerSelect--;
                }
                else if (keyPressed.Key == ConsoleKey.Enter)
                {

                    switch (workerSelect)
                    {
                        case 0:
                            ViewWorkers();
                            Console.WriteLine("Press ENTER to continue...");
                            Console.ReadKey();
                            break;
                        case 1:
                            AddWorker();
                            break;
                        case 2:
                            RemoveWorker();
                            break;
                        case 3:
                            return;

                    }
                }
            }
        }
    }
}
