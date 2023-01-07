namespace ConsoleApp1;

public class ToDoManager
{
    private List<ToDoEntry> _toDoEntries;

    public ToDoManager()
    {
        _toDoEntries = new List<ToDoEntry>();
    }

    public List<ToDoEntry> GetTasks(TaskFilter filter)
    {
        if (filter == TaskFilter.All)
            return _toDoEntries;

        var filteredTasks = new List<ToDoEntry>();
        foreach (var toDoEntry in _toDoEntries)
        {
            if (filter == TaskFilter.Done && toDoEntry.IsDone)
                filteredTasks.Add(toDoEntry);
            else if (filter == TaskFilter.Open && toDoEntry.IsDone == false)
                filteredTasks.Add(toDoEntry);
        }

        return filteredTasks;
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

    public void SetDone(int id)
    {
        bool taskFound = false;
        foreach (var toDoEntry in _toDoEntries)
        {
            if (toDoEntry.Id == id)
            {
                toDoEntry.IsDone = true;
                taskFound = true;
                break;
            }
        }

        if (taskFound == false)
            throw new NullReferenceException($"Can't found a task with id {id}");
    }

    public void Remove(int id)
    {
        bool taskFound = false;
        foreach (var toDoEntry in _toDoEntries)
        {
            if (toDoEntry.Id == id)
            {
                _toDoEntries.Remove(toDoEntry);

                taskFound = true;
                break;
            }
        }

        if (taskFound == false)
            throw new NullReferenceException($"Can't found a task with id {id}");
    }

    public IEnumerable<ToDoEntry> Search(string value)
    {
        foreach (var toDoEntry in _toDoEntries)
        {
            if (toDoEntry.Description.Contains(value, StringComparison.InvariantCultureIgnoreCase))
                yield return toDoEntry;
        }
    }
}

public class ToDoEntry
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }
}

public enum TaskFilter
{
    Open,
    Done,
    All,
}