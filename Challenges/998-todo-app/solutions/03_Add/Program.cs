using ConsoleApp1;

internal class Program
{
    private static ToDoManager _toDoManager;

    static void Main(string[] args)
    {
        _toDoManager = new ToDoManager();

        Console.WriteLine("Willkommen bei ToDo. Mit help siehst du die möglichen Befehle.");
        DetectCommand();
    }

    static void DetectCommand()
    {
        Console.Write("> ");
        var command = Console.ReadLine() ?? "";

        switch (command.ToLower())
        {
            case "help":
                Help();
                break;
            case "exit":
                Environment.Exit(0);
                break;
            case "list":
                List();
                break;
            case { } when command.ToLower().StartsWith("add"):
                Add(command);
                break;
            default:
                Console.WriteLine($"Unkown command: {command}");
                Help();
                break;
        }
    }

    static void Add(string command)
    {
        if (command.Length <= 4)
        {
            Console.WriteLine("Please add description for the task.");
            Help();
        }
        else
        {
            var description = command.Substring(4);

            try
            {
                var todoEntry = _toDoManager.Add(description);
                Console.WriteLine($"Added: #{todoEntry.Id} - {todoEntry.Description}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            DetectCommand();
        }
    }

    static void List()
    {
        var openTasks = _toDoManager.GetTasks();
        if (openTasks.Count == 0)
            Console.WriteLine("No open tasks available. Please add new tasks.");
        else
        {
            foreach (var openTask in openTasks)
            {
                Console.WriteLine($"#{openTask.Id}      {openTask.Description}");
            }
        }

        DetectCommand();
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