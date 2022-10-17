# Das erste Programm und Typengrundlagen

## Erstelle eine neues Projekt in Visual Studio

Öffne Visual Studio auf deinem Rechner und erstelle ein neues Projekt. Es soll sich um eine Konsolenapplikation mit C# handeln. Aktiviere die Option **Do not use top-level statements**, bevor du das Projekt erstellst.

Ersetze `Console.WriteLine("Hello, World!");`, durch die Ausgabe deines Namens. Kompiliere das Programm und führe es aus.

Du kannst nun einen **Breakpoint** auf diese Zeile setzen und das Programm starten. Du wirst sehen wie vor der Ausgabe das Programm am Breakpoint anhält und du die Möglichkeit hast, die Ausführung zu beobachten. Lass das Programm weiterlaufen.

## Die CLI nutzen

> Wenn du im Umgang mit der Kommandozeile unsicher bist, findest du hier die wichtigsten [Befehle](https://www.biteno.com/cmd-befehl-grundlagen-und-einsatzbereiche-bei-windows/)

Öffne eine **Command Prompt** , **Terminal** oder **Powershell**, gehe in das Verzeichnis deines Projekts.

Lass dir eine Liste deiner installierten .NET SDKs anzeigen:

```bash
dotnet --list-sdks
```

Kompliere dein Programm:
```bash
dotnet build
```

Führe dein Programm aus:
```bash
dotnet run
```

Veröffentliche dein Programm mit der dotnet CLI, so das es sich als `.exe` unter Windows ausführen lässt:
```bash
dotnet publish -c Release -r win-x64 --self-contained true
```

## Datentypen

1. Füge den richtigen Datentyp für die folgenden Variablen hinzu:

    ```csharp
    ___ myNum = 9;
    ______ myDoubleNum = 8.99;
    ____ myLetter = 'A';
    ____ myBoolean = false;
    ______ myText = "Hello World";
    ```

2. Erstelle zwei boolesche Variablen mit den Namen yay und nay, und fügen Sie ihnen entsprechende Werte hinzu:

    ```csharp
    bool yay = ___;
    bool nay = ___;
    ```

3. Erstelle eine Begrüßungsvariable und zeigen Sie den Wert dieser Variable an:

    ```csharp
    ______ ________ = "Hello";
    Console.WriteLine(________);
    ```

4. Type Casting - Verwende die richtige Konvertierungsmethode, um die Variable int in eine Zeichenkette zu konvertieren:

    ```csharp
    int myInt = 10;
    Console.WriteLine(Convert.________(_____));
    ```

## Wertetypen: Operationen

1. Multipliziere 10 mit 5, und gebe das Ergebnis aus.

    ```csharp
    Console.WriteLine(10 _ 5);
    ```

2. Teile 10 durch 5 und gebe das Ergebnis aus.

    ```csharp
    Console.WriteLine(10 _ 5);
    ```

3. Verwende den richtigen Operator, um den Wert der Variablen x um 1 zu erhöhen.

    ```csharp
    int x = 10;
    x__;
    ```

4. Verwende den Zuweisungsoperator Addition, um den Wert 5 zur Variablen x zu addieren.

    ```csharp
    int x = 10;
    x __ 5;
    ```

## Mathematische Funktionen

1. Verwende die richtige Methode, um den höchsten Wert von x und y zu auszugeben.

    ```csharp
    int x = 5;
    int y = 10;
    Console.WriteLine(Math.___(x, _));
    ```

2. Verwende die richtige Methode, um die Quadratwurzel von x zu ausgeben.

    ```csharp
    Console.WriteLine(Math.____(64));
    ```

3. Verwende die richtige Methode, um die Zahl 2,6 auf die nächste ganze Zahl zu runden.

    ```csharp
    Console.WriteLine(Math._____(2.6));
    ```

## Projekt: Taschenrechner

Wir bauen einen Taschenrechner! 👨‍💻 Dies geschieht in 3 Iterationen, nach dem Fortschritt unseres Lernprozesses. Dies wird die erste Iteration, die folgende Aufgaben und Funktionsumfang erfasst:

1. Lege ein neues Visual Studio Projekt (Konsolenapplikation) an.
2. Der Benutzer wird aufgefordert zwei Werte einzugeben.
3. Diese Werte werden in den Wertetyp `double` konvertiert und addiert.
4. Das Ergebnis wird aus der Console ausgegeben und das Programm beendet.

## Ressourcen

- [Projekt erstellen](https://learn.microsoft.com/de-de/dotnet/core/tutorials/with-visual-studio?pivots=dotnet-6-0)
- [Datentypen](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/builtin-types/built-in-types)
- [Mathematische Funktionen](https://docs.microsoft.com/de-de/dotnet/api/system.math?view=net-6.0)
- [Zeichenketten Funktionen](https://docs.microsoft.com/de-de/dotnet/api/system.string?view=net-6.0)
- [dotnet CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/)