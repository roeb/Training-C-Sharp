# Patterns & LINQ

## Patterns

Die Lösung findest du unter **Challenges/150-linq/solutions/01_Patterns**.

## LINQ

1. 
    ```csharp
    public static void WeekDays()
    {
        (string ShortDay, string LongDay)[] dayWeek = { ("Su", "Sunday"), ("Mo", "Monday"), ("Tu", "Tuesday"), ("We", "Wednesday"), ("Th", "Thursday"), ("Fr", "Friday"), ("Sa", "Saturday") };

        var days = from WeekDay in dayWeek
                   where WeekDay.ShortDay.StartsWith("S")
                   select WeekDay.LongDay;

        foreach (var WeekDay in days)
        {
            Console.WriteLine(WeekDay);
        }
    }
    ```

2. 
    ```csharp
    public static void NumbersOver60()
    {
        List<int> numbers = new List<int>();

        for (int i = 0; i < 20; i++)
            numbers.Add(new Random().Next(1, 100));

        var numbersOver60 = numbers.Where(n => n > 60).ToList();

        foreach (var num in numbersOver60)
        {
            Console.WriteLine(num);
        }
    }
    ```

3. 
    ```csharp
    public static void NumberInfos()
    {
        List<int> numbers = new List<int>();

        for (int i = 0; i < 20; i++)
            numbers.Add(new Random().Next(1, 100));

        var min = numbers.Min();
        var max = numbers.Max();
        var avg = numbers.Average();
        var sum = numbers.Sum();
        var agr = numbers.Aggregate((a,b) => a * b);


        Console.WriteLine("Min: " + min);
        Console.WriteLine("Max: " + max);
        Console.WriteLine("Avg: " + avg);
        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Agr: " + agr);
    }
    ```

4. 
    ```csharp
    public static void SelectFruits()
    {
        string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape", "strawberry", "blackberry", "gooseberry", "blueberry", "raspberry" };

        var firstWithB = fruits.First(m => m.StartsWith("b"));
        var lastWithG = fruits.Last(m => m.StartsWith("g"));
        var startsWithY = fruits.FirstOrDefault(m => m.StartsWith("y"));

        Console.WriteLine("FirstStartsWithB: " + firstWithB);
        Console.WriteLine("LastStartsWithG: " + lastWithG);
        Console.WriteLine("FirstStartsWithY: " + startsWithY);
    }
    ```

5. 
    ```csharp
    public static void SortAndGroupFruits()
    {
        string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape", "strawberry", "blackberry", "gooseberry", "blueberry", "raspberry" };

        var sortedFruits = fruits.OrderBy(m => m).ToList();
        var groupedFruits = fruits.GroupBy(m => m[0], m => m.Count());

        Console.WriteLine("Sorted Fruits:");
        sortedFruits.ForEach(m => Console.WriteLine(m));

        Console.WriteLine("\nGrouped Fruits:");
        foreach(var group in groupedFruits)
        {
            Console.WriteLine($"{group.Key}: {group.First()}");
        }
    }
    ```

6. 
    ```csharp
    public static void JoinLists()
    {
        (int id, string name)[] departments = { (1, "Backoffice"), (2, "Development"), (3, "Sales") };
        (string Name, int departmentID)[] employees = {
             ("Peter Pan", 2),
             ("Max Mustermann", 1),
             ("Hugo Müller", 2),
             ("Petra Schmidt", 3),
             ("Hans Ludwig", 3),
             ("Georg Kaiser", 4)
        };

        var employeesWithDepartments = employees.Join(departments,
                employee => employee.departmentID, department => department.id,
                (employee, department) => new { employee, department }).ToList();

        employeesWithDepartments.ForEach(e => Console.WriteLine($"{e.employee.Name} arbeitet in {e.department.name}"));
    }
    ```

7. 
    ```csharp
    public static void SkipAndTake()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var skip = numbers.SkipWhile(m => m < 5).ToList();
        var take = numbers.Take(3).ToList();

        Console.WriteLine("Alle Einträge die >= 5 sind: ");
        skip.ForEach(m => Console.WriteLine(m));

        Console.WriteLine("\nDie ersten drei Einträge: ");
        take.ForEach(m => Console.WriteLine(m));
    }
    ```

8. 
    ```csharp
    public static void SelectAndTransform()
    {
        decimal[] numbers = { 3.4M, 8.33M, 5.225M };

        var resultNumbers = numbers.Select(n => Math.Floor(n)).ToList();

        Console.WriteLine("Abgerundete Zahlen: ");
        resultNumbers.ForEach(m => Console.WriteLine(m));

        double[] angles = { 30, 60, 90 };

        var resultAngles = angles.Select(a => new { Angle = a, Cos = Math.Cos(a), Sin = Math.Sin(a) }).ToList();
        Console.WriteLine("\nCalculated values: ");
        resultAngles.ForEach(m => Console.WriteLine($"Angle {m.Angle}: Cos = {m.Cos}, Sin = {m.Sin}"));
    }
    ```

9. 
    ```csharp
    public static void DetectElements()
    {
        string[] names = { "Bob", "Ned", "Amy", "Bill" };
        var containsNamesWithB = names.Any(m => m.StartsWith("B"));
        Console.WriteLine($"Existieren Namen die mit B beginnen?: {containsNamesWithB}");

        int[] numbers = { 1, 3, 5, 7, 9 };
        var exists5Entries = numbers.Contains(5);
        Console.WriteLine($"Existieren 5 Einträge in der Liste?: {exists5Entries}");
    }
    ```

## TimeTracking erweitern

Die Lösung findest du unter **Challenges/150-linq/solutions/02_TimeTracking**.
