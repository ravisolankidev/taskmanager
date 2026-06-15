using TaskManager.Interfaces;
using TaskManager.Services;
using TaskManager.UI;

namespace TaskManager;
    class Program
    {
        static void Main(string[] args)
        {
            LoadMenu();
        }

        private static void LoadMenu()
        {

        ITaskService taskService = new TaskService();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("=== Welcome to Task Manager ===\n");
            Console.WriteLine("Please select an option from the menu below:\n");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks (All)");
            Console.WriteLine("3. View Tasks (Completed)");
            Console.WriteLine("4. View Tasks (Incomplete)");
            Console.WriteLine("5. Complete Task");
            Console.WriteLine("6. Unmark Complete Task");
            Console.WriteLine("7. Delete Task");
            Console.WriteLine("8. Exit\n");
            Console.Write("Select an option: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    MenuHandler.HandleAddTask(taskService);
                    break;
                case "2":
                    MenuHandler.HandleViewTasks(taskService);
                    break;
                case "3":
                    MenuHandler.HandleViewCompletedTasks(taskService);
                        break;
                case "4":
                    MenuHandler.HandleViewIncompleteTasks(taskService);
                    break;
                case "5":
                    MenuHandler.HandleCompleteTask(taskService);
                    break;
                case "6":
                    MenuHandler.HandleUnMarkCompleteTask(taskService);
                    break;
                case "7":
                    MenuHandler.HandleDeleteTask(taskService);
                    break;
                case "8":
                    Console.WriteLine("Exiting Task Manager. Goodbye!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("❌ Invalid option. Press any key to try again...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        }
    }