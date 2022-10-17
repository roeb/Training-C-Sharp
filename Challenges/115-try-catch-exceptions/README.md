# Lambdas & Fehlerbehandlung

## Lambda Expressions - Grundlagen

Wandle die folgenden Code Snippets in effektivere Lambda-Ausdrücke um.

```csharp
public string GetFullName(string firstName, string lastName)
{
    return firstName + " " + lastName;
}
```

```csharp
public class Foo {
    private readonly string _name;

    public Foo(string name) {
        _name = name;
    }
}
```

```csharp
public string CheckSpeed(int speed)
{
    if (speed < 50)
        return "Zu langsam";
    else if (speed >= 50 && speed <= 55)
        return "OK";
    else if (speed > 55 && speed < 70)
        return "Zu schnell";
    else
        return "Viel zu schnell";
}
```

## Die Wetterstation (Lambdas)

In dieser Übung ist die Aufgabe sich bestehenden Code anzuschauen und zu optimieren. Du findest den Code in **Challenges/115-try-catch-exceptions/start/01_Lambdas**.

Die Wetterstation akzeptiert Messwerte und gibt einige Indikatoren wie Temperatur und Druck aus.

1. Verbesserung der Prägnanz und Lesbarkeit geeigneter Methoden

    Gestalte alle geeigneten Methoden der `WeatherStation`Klasse mithilfe von Lambda Expressions um. 

    Verwende gegebenenfalls ternärer bedingter Operator (`?`) und `switch expressions`, um die Lesbarkeit zu verbessern und potenziell Fehler zu reduzieren.

## Fehlerbehandlung

Implementiere verschiedene Arten der Fehlerbehandlung und Ressourcenverwaltung. Du findest den Code zum Starten in **Challenges/115-try-catch-exceptions/start/02_Fehlerbehandlung**.

Ein wichtiger Punkt der Programmierung ist, wie Fehler behandelt und Ressourcen geschlossen werden, selbst wenn Fehler auftreten.

Bei dieser Übung musst du mit verschiedenen Fehlern umgehen.

`HandleErrorByThrowingException()`: Das Ziel ist es hier eine Esxception zu werfen.

`HandleErrorByReturningNullableType(string input)`: Wenn sich der Wert zu `int` kovertieren lässt, gibt diesen zurück. Ansonsten gibt `null` zurück.

`HandleErrorWithOutParam(string input, out int result)`: Wenn sich der Wert zu `int` kovertieren lässt, setze den konvertierten Wert auf den `out` Parameter und gibt `true` zurück. Ansonsten gibt `false` zurück.

`DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)`: Hier sollte eine `Exception`
geworfen werden, aber das übergebene `IDisposable` Objekt, sollte disposed sein.

Hier das Objekt, was du übergeben kannst:

```csharp
private class DisposableResource : IDisposable
{
    public bool IsDisposed { get; private set; }

    public void Dispose()
    {
        IsDisposed = true;
    }
}
```

## Benutzerdefinierte Ausnahme

Du findest den Code zum Starten in **Challenges/115-try-catch-exceptions/start/03_Custom_Exceptions**.

Du erstellst einen Testrahmen, um eine Reihe von Taschenrechnerfunktionen zu überprüfen, beginnend mit der Multiplikation. Du wirst sehen, dass es besondere Herausforderungen gibt, wenn die beiden Operanden der Multiplikation negativ sind.

Die `Calculator`Klasse wurde für Sie bereitgestellt und sollte nicht geändert werden.

1. Vervollständige die Definition der benutzerdefinierten Ausnahme `CalculationException`

    Vervollständige die Definition des Konstruktors, der `CalculationException` alle vom Taschenrechner ausgelösten Ausnahmen sowie die Operanden, die zum Zeitpunkt des Auslösens der Ausnahme verarbeitet werden, speichern (verpacken) muss.

2. Umgang mit Überlaufbedingungen im Rechner und Bereitstellung erweiterter Informationen für den Anrufer

    Implementiere `CalculatorTestHarness.Multiply()`, welche wiederum `Calculator.Multiply()` im `Calculator` aufruft. 
    
    Wenn es zu einem Überlauf in ``Calculator.Multiply()`` kommt, soll eine `OverflowException` geworfen werden. Dieser Fehler sollte in `CalculatorTestHarness.Multiply()` abgefangen werden und in eine `CalculationException` umgewandelt werden. Dabei sollte `x` und `y` als Informationen in der Exception bereitgestellt werden.

    Nun sollte die eben erstellte `CalculationException` geworfen werden.

    ```csharp
    var cth = new CalculatorTestHarness(new Calculator());
    cth.Multiply(Int32.MaxValue, Int32.MaxValue);
    // => throws an instance of CalculationException

    var cth2 = new CalculatorTestHarness(new Calculator());
    cth2.Multiply(3, 2);
    // => silently exits
    ```

3. Teste die Multiplikationsoperation auf gültige Eingaben

    Implementiere die `CalculatorTestHarness.TestMultiplication()`Methode, die zwei ganze Zahlen akzeptiert und die Methode `CalculatorTestHarness.Multiply()`aufruft. `"Multiply succeeded"` sollte zurück kommen.

    ```csharp
    var cth = new CalculatorTestHarness(new Calculator());
    cth.TestMultiplication(6, 7);
    // => "Multiply succeeded"
    ```

4. Teste die Multiplikationsoperation für negative Eingaben

    Ändere die `CalculatorTestHarness.TestMultiplication()` Methode so, dass sie `"Multiply failed for negative operands. <INNER_EXCEPTION_MESSAGE>"` zurückgegeben wird, wenn beide ganzzahligen Argumente negativ (kleiner als Null) sind.

    Der `<INNER_EXCEPTION_MESSAGE>` Platzhalter sollte durch die `InnerException` von `CalculationException` ersetzt werden.

    ```csharp
    var cth = new CalculatorTestHarness(new Calculator());
    cth.TestMultiplication(-2, -Int32.MaxValue);
    // => "Multiply failed for negative operands. " + innerException.Message
    ```

5. Teste die Multiplikationsoperation für positive Eingaben

    Ändere die `CalculatorTestHarness.TestMultiplication()` Methode so, dass sie `"Multiply failed for mixed or positive operands. <INNER_EXCEPTION_MESSAGE>"` zurückgegeben wird, wenn mindestens eines der ganzzahligen Argumente nicht negativ ist.

    Der `<INNER_EXCEPTION_MESSAGE>` Platzhalter sollte durch die `InnerException` von `CalculationException` ersetzt werden.

    ```csharp
    var cth = new CalculatorTestHarness(new Calculator());
    cth.TestMultiplication(Int32.MaxValue, Int32.MaxValue);
    // => "Multiply failed for mixed or positive operands. " + innerException.Message
    ```

## Bank Account

Du findest den Code zum Starten in **Challenges/115-try-catch-exceptions/start/04_Bank_Account1**.

Simuliere ein Bankkonto, das das Öffnen/Schließen, Abheben und Einzahlen von Geld unterstützt. Achten Sie auf gleichzeitige Transaktionen!

Auf ein Bankkonto kann auf mehrere Arten zugegriffen werden. Kunden können Ein- und Auszahlungen über das Internet, Mobiltelefone usw. vornehmen. Geschäfte können das Konto belasten.

Erstelle ein Konto, auf das von mehreren Threads/Prozessen aus zugegriffen werden kann.

Es sollte möglich sein, ein Konto zu schließen; Operationen gegen ein geschlossenes Konto müssen fehlschlagen.

## Taschenrechner

Prüfe ob eine unbekannte `Operation` übergeben wird und werfe eine `NotSupportedException` mit dem Hinweis, das dieser Operator nicht unterstützt wird.

Am Anfang deines Programms, werden die eingegebenen Rechenwerte und der eingegebene Operator konvertiert (`double`, `Operation`). Bei hier ein Fehlerbehandlung ein, so das dein Programm nicht abstürzt, sondern eine klare Fehlermeldung ausgibt.

## Ressourcen

[Lambda Expresssions](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/operators/lambda-expressions)

[Ternärer Operator](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/operators/conditional-operator)

[Switch Expressions](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/operators/switch-expression)

[using](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/keywords/using-statement)

[TryParse](https://docs.microsoft.com/de-de/dotnet/api/system.int32.tryparse?view=net-6.0)

[lock](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/keywords/lock-statement)