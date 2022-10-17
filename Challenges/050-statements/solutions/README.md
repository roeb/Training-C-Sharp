# Arrays, null, Modifikator und Auswahlbedingungen

## Arbeiten mit Arrays

1. 
    ```csharp
    int[] array = new int[2];
    ```

2. 
    ```csharp
    array[0]=1;
    array[1]=2;
    ```

3. 
    ```csharp
    var array = new[] { "Hallo", "Welt" };
    ```

4. 
    ```csharp
    var array = new int[100];
    for (int i = 0; i < 100; i++)
    {
        array[i] = i;
    }
    ```

5. 
    ```csharp
    var array = new int[100];
    for (int i = 0; i < 100; i++)
    {
        array[i] = i;
    }

    var copiedArray = new int[100];
    Array.Copy(array, copiedArray, array.Length);

    for (int i = 0; i < array.Length - 1; i++)
    {
        if (array[i] % 2 == 1)
            copiedArray[i] = 0;
    }

    foreach (var item in copiedArray)
        if (item != 0)
            Console.WriteLine(item);

    Console.ReadKey();
    ```

## Methoden und Modifikatoren

1. 
    ```csharp
    public static double NegativeOrPositive(double num)
    {
        return num < 0 ? Math.Pow(num, 2) : Math.Sqrt(num);
    }
    ```

2. 
    ```csharp
    public static string ReplaceXWithY(string word)
    {
        string[] words = word.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Contains("y"))
            {
                words[i] = words[i].Replace("y", "x");
            }
        }

        return String.Join(" ", words);
    }
    ```

3. 
    ```csharp
    public static void ToLowerOrToUpper(string word, out string convertedString)
    {
        string[] words = word.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = i % 2 == 0 ? words[i].ToUpper() : words[i].ToLower();
        }

        convertedString = String.Join(" ", words);
    }
    ```

## Switch und Überladungen von Methoden

Die Lösung findest du im Order **Challenges/050-statements/solutions/00_Football**.

## Der Getränkeautomat

Die Lösung findest du im Order **Challenges/050-statements/solutions/01_Getraenkeautomat**.

## Herausforderung: Maximum, Minimum, Mittelwert

```csharp
int[] arr = new int[10];
Random rd = new Random();

// Array mit Zufallszahlen belegen
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = rd.Next(100);
}

for (int i = 0; i < arr.Length; i++)
    Console.WriteLine(arr[i]);


// Maximum bestimmen
int max = arr[0];
for (int i = 0; i < arr.Length; i++)
    if (max < arr[i])
        max = arr[i];

Console.WriteLine("max = " + max);

// Minimum bestimmen
int min = arr[0];
for (int i = 0; i < arr.Length; i++)
    if (min > arr[i])
        min = arr[i];

Console.WriteLine("min = " + min);

// Mittelwert bestimmen
double mittel = 0;
for (int i = 0; i < arr.Length; i++)
    mittel += arr[i];

mittel /= arr.Length;
Console.WriteLine("Mittelwert = " + mittel);

Console.ReadKey();
```

## Projekt: Taschenrechner

Das fertige Projekt findest du im Order **Challenges/050-statements/solutions/02_Calc_Iteration_02**.