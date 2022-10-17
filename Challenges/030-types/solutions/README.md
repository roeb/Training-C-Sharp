# Das erste Programm und Typengrundlagen

## Erstelle eine neues Projekt in Visual Studio

Das fertige Projekt findest du im Order **Challenges/030-types/solutions/01_HelloWorld**.

## Datentypen

1. Füge den richtigen Datentyp für die folgenden Variablen hinzu:

    ```csharp
    int myNum = 9;
    double myDoubleNum = 8.99;
    char myLetter = 'A';
    bool myBoolean = false;
    string myText = "Hello World";
    ```

2. Erstelle zwei boolesche Variablen mit den Namen yay und nay, und fügen Sie ihnen entsprechende Werte hinzu:

    ```csharp
    bool yay = true;
    bool nay = false;
    ```

3. Erstelle eine Begrüßungsvariable und zeigen Sie den Wert dieser Variable an:

    ```csharp
    string greeting = "Hello";
    Console.WriteLine(greeting);
    ```

4. Type Casting - Verwende die richtige Konvertierungsmethode, um die Variable int in eine Zeichenkette zu konvertieren:

    ```csharp
    int myInt = 10;
    Console.WriteLine(Convert.ToString(myInt));
    ```

## Wertetypen: Operationen

1. Multipliziere 10 mit 5, und gebe das Ergebnis aus.

    ```csharp
    Console.WriteLine(10 * 5);
    ```

2. Teile 10 durch 5 und gebe das Ergebnis aus.

    ```csharp
    Console.WriteLine(10 / 5);
    ```

3. Verwende den richtigen Operator, um den Wert der Variablen x um 1 zu erhöhen.

    ```csharp
    int x = 10;
    x++;
    ```

4. Verwende den Zuweisungsoperator Addition, um den Wert 5 zur Variablen x zu addieren.

    ```csharp
    int x = 10;
    x += 5;
    ```

## Mathematische Funktionen

1. Verwende die richtige Methode, um den höchsten Wert von x und y zu auszugeben.

    ```csharp
    Console.WriteLine(Math.Max(x, y));

    ```

2. Verwende die richtige Methode, um die Quadratwurzel von x zu ausgeben.

    ```csharp
    Console.WriteLine(Math.Sqrt(64));
    ```

3. Verwende die richtige Methode, um die Zahl 2,6 auf die nächste ganze Zahl zu runden.

    ```csharp
    Console.WriteLine(Math.Round(2.6));
    ```

## Projekt: Taschenrechner

Das fertige Projekt findest du im Order **Challenges/030-types/solutions/02_Calc_Iteration_01**.
