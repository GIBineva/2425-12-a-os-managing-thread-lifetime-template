using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Processes
{
    private static Dictionary<int, Task> tasks = new Dictionary<int, Task>();
    private static Random random = new Random();
    private static int pidCounter = 1000;
    private static object lockObj = new object();
    private static int totalCpuUsage = 0;
    private const int MaxCpuUsage = 100;

    public static void StartNewTask()
    {
        int cpuUsage = random.Next(10, 30);

        lock (lockObj)
        {
            if (totalCpuUsage + cpuUsage > MaxCpuUsage)
            {
                Console.WriteLine($"Cannot start task! CPU usage limit exceeded ({totalCpuUsage}% / {MaxCpuUsage}%)");
                return;
            }

            totalCpuUsage += cpuUsage;
            int pid = pidCounter++;
            Task newTask = new Task(pid, cpuUsage);
            tasks[pid] = newTask;
        }
    }

    public static void ListRunningTasks()
    {
        Console.WriteLine("\nRunning Tasks:");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No running tasks.");
            return;
        }

        foreach (var task in tasks.Values)
        {
            string status = task.IsRunning ? "Running" : "Suspended";
            Console.WriteLine($"PID: {task.PID}, Status: {status}, CPU: {task.CpuUsage}%");
        }
        Console.WriteLine($"Total CPU Usage: {totalCpuUsage}%");
    }

    public static void ToggleTask(int pid)
    {
        lock (lockObj)
        {
            if (!tasks.ContainsKey(pid))
            {
                Console.WriteLine("Invalid PID!");
                return;
            }

            var task = tasks[pid];
            if (task.IsRunning)
            {
                task.Suspend();
                totalCpuUsage -= task.CpuUsage;
            }
            else
            {
                if (totalCpuUsage + task.CpuUsage > MaxCpuUsage)
                {
                    Console.WriteLine($"Cannot resume task! CPU usage limit exceeded ({totalCpuUsage}% / {MaxCpuUsage}%)");
                    return;
                }

                task.Resume();
                totalCpuUsage += task.CpuUsage;
            }
        }
    }

    public static void TerminateAllTasks()
    {
        Console.WriteLine("Terminating all tasks...");
        foreach (var task in tasks.Values)
        {
            task.Resume(); // Ensure all tasks are running before stopping them
            task.Thread.Abort();
        }
        tasks.Clear();
        Console.WriteLine("All tasks terminated.");
    }
}
