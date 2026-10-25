using System.Diagnostics;

public class CommandLineArgsExample
{
    public static void Main(string[] args)
    {
        string verb = "";
        
        // Check if any arguments were provided
        if (args.Length > 0)
        {
            // Print the first argument
            // Console.WriteLine("First argument: " + args[0]);
            if (args[0] == "up")
            {
                verb = "start";
                Console.WriteLine("Revivin' 'em all!");
            }
        }
        else
        {
            // Console.WriteLine("No arguments provided.");
            verb = "stop";
            Console.WriteLine("Killin' 'em all!");
        }

        string[] services = {"bpftune.service", "containerd.service", "docker.service", "docker.socket", "ollama.service"};

        foreach (string service in services)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "/usr/bin/systemctl", Arguments = verb + " " + service, }; 
            Process proc = new Process() { StartInfo = startInfo, };
            proc.Start();
            proc.WaitForExit();
        }
    }
}



