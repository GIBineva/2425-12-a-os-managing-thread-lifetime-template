using System;
using System.Threading;

class Task
{
    public int PID { get; private set; }
    public Thread Thread { get; private set; }
    public ManualResetEventSlim PauseEvent { get; private set; }
    public bool IsRunning { get; private set; }
    public int CpuUsage { get; private set; }

    public Task(int pid, int cpuUsage)
    {
        PID = pid;
        CpuUsage = cpuUsage;
        PauseEvent = new ManualResetEventSlim(true);
        IsRunning = true;

        Thread = new Thread(() =>
        {
            Console.WriteLine($"Task {PID} started with {CpuUsage}% CPU usage.");
            while (true)
            {
                PauseEvent.Wait();
                Thread.Sleep(1000); // Simulate work
            }
        })
        { IsBackground = true };

        Thread.Start();
    }

    public void Suspend()
    {
        PauseEvent.Reset();
        IsRunning = false;
        Console.WriteLine($"Task {PID} suspended.");
    }

    public void Resume()
    {
        PauseEvent.Set();
        IsRunning = true;
        Console.WriteLine($"Task {PID} resumed.");
    }
}
