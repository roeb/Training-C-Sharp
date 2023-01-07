using System.Diagnostics;
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
            case { } when command.ToLower().StartsWith("list"):
                List(command);
                break;
            case { } when command.ToLower().StartsWith("add"):
                Add(command);
                break;
            case { } when command.ToLower().StartsWith("done"):
                SetDone(command);
                break;
            case { } when command.ToLower().StartsWith("remove"):
                Remove(command);
                break;
            default:
                Console.WriteLine($"Unkown command: {command}");
                Help();
                break;
        }
    }

    static void Remove(string command)
    {
        if (!int.TryParse(command.Replace("remove ", ""), out int taskId))
        {
            Console.WriteLine("Please use valid task id.");
            Help();
        }
        else
        {
            try
            {
                _toDoManager.Remove(taskId);
                Console.WriteLine($"Task #{taskId} is removed!");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            DetectCommand();
        }
    }

    static void SetDone(string command)
    {
        if (!int.TryParse(command.Replace("done ", ""), out int taskId))
        {
            Console.WriteLine("Please use valid task id.");
            Help();
        }
        else
        {
            try
            {
                _toDoManager.SetDone(taskId);
                Console.WriteLine($"Task #{taskId} is done now!");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            DetectCommand();
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

    static void List(string command)
    {
        var taskFilter = TaskFilter.All;

        var filterText = command.Replace("list ", "");
        if (filterText.ToLower() == "done")
            taskFilter = TaskFilter.Done;
        else if (filterText.ToLower() == "open")
            taskFilter = TaskFilter.Open;

        var openTasks = _toDoManager.GetTasks(taskFilter);
        if (openTasks.Count == 0)
            Console.WriteLine("No tasks available. Please add new tasks.");
        else
        {
            foreach (var openTask in openTasks)
            {
                var status = openTask.IsDone switch
                {
                    true => "Done",
                    false => "Open"
                };

                Console.WriteLine($"#{openTask.Id}      {openTask.Description} ({status})");
            }
        }

        DetectCommand();
    }

    static void Help()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("     list all | done | open  List all tasks");
        Console.WriteLine("     add [item]              Add task to list");
        Console.WriteLine("     done #[number]          Complete a task");
        Console.WriteLine("     remove #[number]        Remove a task");
        Console.WriteLine("     search [text]           Search in all tasks with the value");
        Console.WriteLine("     help                    Shows all possible commands");
        Console.WriteLine("     exit                    Exit the application");


        DetectCommand();
    }
}