# Delegates und Events

## Delegate

**Aufgabe 1:**

```csharp
static void Main(string[] args)
{
    TextOperation handler = new TextOperation(TextToUpper);
    string result = handler.Invoke("Hallo Welt");

    Console.WriteLine("Result: " + result);

    Console.ReadKey();
}

public delegate string TextOperation(string text);


public static string TextToUpper(string text)
{
    return text.ToUpper();
} 
```

**Aufgabe 2:**

```csharp
static void Main(string[] args)
{
    string input = "Hallo Welt";

    TextOperation handler = new TextOperation(TextToUpper); ;
    handler += new TextOperation(ReplaceWhitespace); ;
    handler += new TextOperation(ReplaceTWith7); ;

    string result = handler.Invoke(ref input);

    Console.WriteLine($"Input: Hallo Welt; Result: {result}");

    Console.ReadKey();
}

public delegate string TextOperation(ref string text);


public static string TextToUpper(ref string text)
{
    return text = text.ToUpper();
}

public static string ReplaceWhitespace(ref string text)
{
    return text = text.Replace(" ", "-");
}

public static string ReplaceTWith7(ref string text)
{
    return text = text.Replace("T", "7");
}
```

## Events

Die Lösung findest du im Order **Challenges/100-events/solutions/02_Events**.

## Countdown

Die Lösung findest du im Order **Challenges/100-events/solutions/03_Countdown**.

