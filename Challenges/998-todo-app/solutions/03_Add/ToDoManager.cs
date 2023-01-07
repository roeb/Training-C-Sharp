namespace ConsoleApp1;

public class ToDoManager
{
    private List<ToDoEntry> _toDoEntries;

    public ToDoManager()
    {
        _toDoEntries = new List<ToDoEntry>();
    }

    public List<ToDoEntry> GetTasks()
    {
        var openTasks = new List<ToDoEntry>();
        foreach (var toDoEntry in _toDoEntries)
        {
            if (toDoEntry.IsDone == false)
                openTasks.Add(toDoEntry);
        }

        return openTasks;
    }

    public ToDoEntry Add(string description)
    {
        foreach (var toDoEntry in _toDoEntries)
        {
            if (toDoEntry.Description.ToLower() == description.ToLower())
                throw new ArgumentException($"Task with '{description}' already exists.");
        }
        
        var todoEntry = new ToDoEntry()
        {
            Id = _toDoEntries.Count > 0 ? _toDoEntries.Max(m => m.Id) + 1 : 1,
            Description = description,
            IsDone = false
        };

        _toDoEntries.Add(todoEntry);

        return todoEntry;
    }
}

public class ToDoEntry
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }
}