using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var employee = new Employee(Guid.NewGuid(), "Peter Pan", new Department("Backoffice", "Munich"));

        var timeRecording = new TimeRecording();
        timeRecording.AddTimeEntry(employee, new TimeEntry(DateTime.Today, 12.5));

        Console.WriteLine(timeRecording.GetTimeEntry(employee).workingHours);
        Console.ReadKey();
    }
}


public class TimeRecording
{
    private Dictionary<Guid, TimeEntry> _timeEntries = new Dictionary<Guid, TimeEntry>(); 

    public void AddTimeEntry(Employee employee, TimeEntry timeEntry)
    {
        if (!_timeEntries.ContainsKey(employee.id))
            _timeEntries.Add(employee.id, timeEntry);
    }

    public TimeEntry GetTimeEntry(Employee employee) => _timeEntries[employee.id];
    
}

public record Department(string name, string location);

public record Employee(Guid id, string name, Department department);

public record struct TimeEntry(DateTime day, double workingHours);