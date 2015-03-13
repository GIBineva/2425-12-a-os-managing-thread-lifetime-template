using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nTask Manager:");
            Console.WriteLine("1. Start a new task");
            Console.WriteLine("2. List running tasks");
            Console.WriteLine("3. Resume/Suspend task by PID");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Processes.StartNewTask();
                    break;
                case "2":
                    Processes.ListRunningTasks();
                    break;
                case "3":
                    Console.Write("Enter PID to Resume/Suspend: ");
                    if (int.TryParse(Console.ReadLine(), out int pid))
                    {
                        Processes.ToggleTask(pid);
                    }
                    else
                    {
                        Console.WriteLine("Invalid PID!");
                    }
                    break;
                case "4":
                    Processes.TerminateAllTasks();
                    return;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }
}
