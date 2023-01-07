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
            if(toDoEntry.IsDone == false)
                openTasks.Add(toDoEntry);
        }

        return openTasks;
    }
}

public class ToDoEntry
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }
}