# Extensions Methods, Anonymous Types, Tupel und Records

## Extensions Methods

In dieser Übung verarbeitest du Protokollzeilen.

Jede Protokollzeile ist eine Zeichenfolge, die wie folgt formatiert ist: `"[<LEVEL>]: <MESSAGE>"`.

Es gibt drei verschiedene Protokollebenen:

- `INFO`
- `WARNING`
- `ERROR`

1. Ermögliche das Abrufen der Zeichenfolge nach einer bestimmten Teilzeichenfolge

    Wenn du dir die Protokolle des letzten Monats ansiehst, siehst du, dass sich die Testnachricht immer nach einem bestimmten Teilstring befindet. Da du davon ausgehst, dass du die Testnachricht irgendwann in naher Zukunft extrahieren musst, entscheidest du dich, eine Hilfsmethode zu erstellen, die dir dabei hilft.

    Implementiere die `LogAnalysis.SubstringAfter()` Erweiterungsmethode, die ein Zeichenfolgentrennzeichen aufnimmt und die Teilzeichenfolge nach dem Trennzeichen zurückgibt.

    ```csharp
    var log = "[INFO]: File Deleted.";
    log.SubstringAfter(": "); // => returns "File Deleted."
    ```

2. Ermögliche das Abrufen der Zeichenfolge zwischen zwei Teilzeichenfolgen

    Bei näherer Betrachtung siehst du, dass die Protokollebene immer zwischen eckigen Klammern (`[]`) steht. Da du auch damit rechnest, die Protokollebene irgendwann in naher Zukunft extrahieren zu müssen, entscheidest du dich, eine weitere Hilfsmethode zu erstellen, die dir dabei hilft.

    Implementiere die `LogAnalysis.SubstringBetween()` Erweiterungsmethode, die zwei String-Trennzeichen akzeptiert und die Teilzeichenfolge zurückgibt, die zwischen den beiden Trennzeichen liegt.

    ```csharp
    var log = "[INFO]: File Deleted.";
    log.SubstringBetween("[", "]"); // => returns "INFO"
    ```

3. Nachricht in einem Protokoll parsen

    Implementiere die `LogAnalysis.Message()` Erweiterungsmethode, um die in einem Protokoll enthaltene Nachricht zurückzugeben.

    ```csharp
    var log = "[ERROR]: Missing ; on line 20.";
    log.Message(); // => returns "Missing ; on line 20."
    ```

4. Analysiere die Protokollebene in einem Protokoll

    Implementiere die `LogAnalysis.LogLevel()` Erweiterungsmethode, um die Protokollebene eines Protokolls zurückzugeben.

    ```csharp
    var log = "[ERROR]: Missing ; on line 20.";
    log.LogLevel(); // => returns "ERROR"
    ```

## Tupel

In dieser Übung analysierst du Telefonnummern.

An die Methoden übergebene Telefonnummern haben garantiert die Form `NNN-NNN-NNNN`, z. B. `212-515-9876`, und sind nicht null.

1. Analysiere eine Telefonnummer

    Deine Analyse sollte 3 Datenelemente zurückgeben_

    - Ein Hinweis darauf, ob die Nummer eine New Yorker Vorwahl hat, dh. 212 als die ersten 3 Ziffern
    - Ein Hinweis darauf, ob die Nummer gefälscht ist, mit 555 als Präfixcode in den Positionen 5 bis 7 (Nummerierung von 1)
    - Die letzten 4 Ziffern der Nummer.

    Implementiere die Methode `PhoneNumber.Analyze()`, um die Telefonnummerninformationen zu erzeugen. Verwende als Rückgabetyp einen Tupel. Der Parameter ist ein `string`.

    ```csharp
    PhoneNumber.Analyze("631-555-1234");
    // => (false, true, "1234")
    ```

2. Erkenne, ob eine Telefonnummer eine gefälschte Vorwahl hat (555)

    Implementiere die Methode `PhoneNumber.IsFake()`, um anhand der in Aufgabe 1 erzeugten Telefonnummerninformationen zu erkennen, ob die Telefonnummer gefälscht ist.

    Übergebe in dieser Funktion ein Tupel als Parameter mit den Information aus Aufgabe 1 und gibt ein `bool` zurück.

    ```csharp
    PhoneNumber.IsFake(PhoneNumbers.Analyze("631-555-1234"));
    // => true
    ```

## Records

In dieser Aufgabe bauen wir eine kleine primitive Zeiterfassung (wir bauen diese später weiter aus). Die Zielsetzung ist es das für jeden Mitarbeiter exakt eine Zeit erfasst werden kann und auch wieder ausgegeben wird.

1. Erstellen der Klasse `TimeRecording`

    Du erstellst eine Klasse `TimeRecording`, welche zwei Funktionen beinhaltet. Die Records erstellen wir in der nächsten Aufgabe.

    - `void AddTimeEntry(Employee employee, TimeEntry timeEntry)`
    - `TimeEntry GetTimeEntry(Employee employee)`

2. Erstellen der Records

    Du benötigst drei Records
    
    - `Employee`: Besteht aus einer ID (`Guid`, siehe Referenzen), Name und einem Department
    - `Department`: Besteht aus einem Namen und einem Ort wo die Abteilung ansässig ist
    - `TimeEntry`: Besteht aus einem `DateTime` für den Tag und ein Zahlenwert für die gearbeiteten Stunden an diesem Tag. Denke außerdem an deine Erfahrung mit Structs und überlege ob du das wissen hier anwenden kannst.

3. Funktionalität implementieren

    Die Funktion `AddTimeEntry` soll nun den übergebenen Eintrag in internes Dictionary legen  
    
    Wo hingegen `GetTimeEntry` den Eintrag für den übergebenen Mitarbeiter aus dem Dictionary zurückgeben soll.

## Taschenrechner

Ersetze streng typisierte Variablen durch anonyme Typen (`var`).

Die Klasse die du momentan für deine History verwendest (z.B. `CalculatorHistory`) solltest du durch einen Record ersetzen.

Im Konstruktor von deiner abstrakten Basisklasse (z.B. `CalculateOperation`) werden aktuell zwei Werte übergeben. Hier kannst du einen Tupel nutzen um die Werte zu übergeben.

## Ressourcen

[Extension Methods](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)

[Anonymous Types](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/classes-and-structs/anonymous-types)

[Tupel](https://docs.microsoft.com/de-de/dotnet/csharp/tuples)

[Records](https://learn.microsoft.com/de-de/dotnet/csharp/language-reference/builtin-types/record)

[Guid](https://docs.microsoft.com/de-de/dotnet/api/system.guid?view=net-6.0)

[Struct](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/builtin-types/struct)

[Dictionary](https://docs.microsoft.com/de-de/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0)