internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Willkommen bei ToDo. Mit help siehst du die möglichen Befehle.");
        DetectCommand();
    }

    static void DetectCommand()
    {
        Console.Write("> ");
        var command = Console.ReadLine();

        switch (command.ToLower())
        {
            case "help":
                Help();
                break;
            case "exit":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine($"Unkown command: {command}");
                Help();
                break;
        }
    }

    static void Help()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("     list                List all tasks");
        Console.WriteLine("     add [item]          Add task to list");
        Console.WriteLine("     done #[number]      Complete a task");
        Console.WriteLine("     remove #[number]    Remove a task");
        Console.WriteLine("     search [text]       Search in all tasks with the value");
        Console.WriteLine("     help                Shows all possible commands");
        Console.WriteLine("     exit                Exit the application");

        
        DetectCommand();
    }
}