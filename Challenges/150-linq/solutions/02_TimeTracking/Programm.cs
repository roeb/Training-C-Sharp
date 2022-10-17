using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var employee = new Employee(Guid.NewGuid(), "Peter Pan", new Department("Backoffice", "Munich"));

        var timeRecording = new TimeRecording();
        timeRecording.AddTimeEntry(employee, new TimeEntry(DateTime.Today, new TimeSpan(2, 50, 0)));
        timeRecording.AddTimeEntry(employee, new TimeEntry(DateTime.Today, new TimeSpan(1, 10, 0)));
        timeRecording.AddTimeEntry(employee, new TimeEntry(DateTime.Today, new TimeSpan(3, 20, 0)));

        Console.WriteLine("Arbeitszeit heute: ");
        Console.WriteLine(timeRecording.GetTotalWorkingHours(employee, DateTime.Today));

        timeRecording.AddTimeEntry(employee, new TimeEntry(DateTime.Today.AddDays(-2), new TimeSpan(1, 20, 0)));
        timeRecording.AddTimeEntry(employee, new TimeEntry(DateTime.Today.AddDays(-2), new TimeSpan(4, 50, 0)));

        Console.WriteLine("\nArbeitszeit in den letzten beiden Tagen: ");
        Console.WriteLine(timeRecording.GetTotalWorkingHours(employee, DateTime.Today.AddDays(-2), DateTime.Today));

        Console.ReadKey();
    }
}


public class TimeRecording
{
    private Dictionary<Guid, List<TimeEntry>> _timeEntries = new Dictionary<Guid, List<TimeEntry>>();

    public void AddTimeEntry(Employee employee, TimeEntry timeEntry)
    {
        if (!_timeEntries.ContainsKey(employee.id))
            _timeEntries.Add(employee.id, new List<TimeEntry>() { timeEntry });
        else
            _timeEntries[employee.id].Add(timeEntry);
    }

    public string GetTotalWorkingHours(Employee employee, DateTime day)
    {
        var totalTicks = _timeEntries[employee.id].Where(m => m.day.Date == day.Date).Sum(m => m.workingTime.Ticks);
        var totalTime = new TimeSpan(totalTicks);
        return $"{totalTime.Hours}:{totalTime.Minutes}";
    }

    public string GetTotalWorkingHours(Employee employee, DateTime startDate, DateTime endDate)
    {
        var totalTicks = _timeEntries[employee.id]
            .Where(m => m.day.Date >= startDate.Date && m.day.Date <= endDate.Date)
            .Sum(m => m.workingTime.Ticks);

        var totalTime = new TimeSpan(totalTicks);
        return $"{totalTime.Hours}:{totalTime.Minutes}";
    }
}

public record Department(string name, string location);

public record Employee(Guid id, string name, Department department);

public record struct TimeEntry(DateTime day, TimeSpan workingTime);