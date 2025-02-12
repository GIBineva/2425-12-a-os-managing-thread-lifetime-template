namespace TaskManager;

class Process
{
    public int PID { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public Thread ProcessThread { get; set; }
    
    public Process()
    {
        PID = new Random().Next(100000);
        Name = GenerateName();
        Status = "Running";
    }

    private string GenerateName()
    {
        int randomLength = new Random().Next(5,10);
        char[] chars = new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

        string randomName = "";
        
        for (int i = 0; i < randomLength; i++)
        {
            randomName += chars[new Random().Next(chars.Length)];
        }
        
        return randomName + ".exe";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Process> processes = new List<Process>();

        for (int i = 0; i < new Random().Next(100); i++)
        {
            processes.Add(new Process());
        }

        Console.WriteLine("\tName\t|\tPID\t|\tStatus");

        foreach (Process process in processes)
        {
            Console.WriteLine($"{process.Name}\t|\t{process.PID}\t|\t{process.Status}");
        }
        
        Console.ReadKey();
    }
}