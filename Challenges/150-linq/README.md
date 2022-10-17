# Patterns & LINQ

## Patterns

**Nutze für diese Übung Patterns!**

In dieser Übung schreibst du Code, um die Produktion eines Fließbands in einer Autofabrik zu analysieren. Die Geschwindigkeit des Fließbands kann von `0` (aus) bis `10` (maximal) reichen.

Bei der niedrigsten Geschwindigkeit (`1`) werden stündlich `221` Autos produziert. Die Produktion steigt linear mit der Geschwindigkeit. Wenn die Geschwindigkeit also auf `4` eingestellt ist, sollte sie `4 * 221 = 884` Autos pro Stunde produzieren. Höhere Geschwindigkeiten erhöhen jedoch die Wahrscheinlichkeit, dass fehlerhafte Autos produziert werden, die dann ausgemustert werden müssen.

1. Berechne die Erfolgsquote

    Implementiere die `AssemblyLine.SuccessRate()` Methode, um das Verhältnis eines fehlerfrei erstellten Elements für eine bestimmte Geschwindigkeit zu berechnen. Die folgende Tabelle zeigt, wie die Geschwindigkeit die Erfolgsquote beeinflusst:

    - `0`: 0% Erfolgsquote.
    - `1` bis `4`: 100% Erfolgsquote.
    - `5` bis `8`: 90% Erfolgsquote.
    - `9`: 80 % Erfolgsquote.
    - `10`: 77 % Erfolgsquote.

    ```csharp
    AssemblyLine.SuccessRate(10)
    // => 0.77
    ```

2. Berechne die Produktionsrate pro Stunde

    Implementiere die `AssemblyLine.ProductionRatePerHour()` Methode zur Berechnung der Produktionsrate der Montagelinie pro Stunde unter Berücksichtigung ihrer Erfolgsrate:

    ```csharp
    AssemblyLine.ProductionRatePerHour(6)
    // => 1193.4
    ```

    Beachten dass der zurückgegebene Wert eine `double` ist.

3. Berechne die Anzahl der pro Minute produzierten Arbeitseinheiten

    Implementiere die `AssemblyLine.WorkingItemsPerMinute()` Methode, um zu berechnen, wie viele funktionierende Autos pro Minute produziert werden:

    ```csharp
    AssemblyLine.WorkingItemsPerMinute(6)
    // => 19
    ```

    Beachten dass der zurückgegebene Wert eine int.

## LINQ

1. Wochentage mit S

    Schreibe eine Funktion `WeekDays` die aus der folgenden Liste, alle Wochentag die mit "S" beginnen, zurückgibt. In der Ausgabe sollen jedoch nur die lange Version des Tages ausgegeben werden.

    Liste der Wochentage: 
    ```csharp
    (string ShortDay, string LongDay)[] dayWeek = { ("Su", "Sunday"), ("Mo", "Monday"), ("Tu", "Tuesday"), ("We", "Wednesday"), ("Th", "Thursday"), ("Fr", "Friday"), ("Sa", "Saturday") };
    ```

    Die Ausgabe soll wie folgt aussehen:
    ```csharp
    ["Sunday", "Saturday"]
    ```

2. Zahlen über 60

    Erzeuge mit der `Random` Klasse 20 Zahlen im Wertebereich von 1 - 100. Schreibe eine Funktion `NumbersOver60` die alle Zahlen über 60 ausgibt.

3. Druchschnitt berechnen

    Erzeuge mit der `Random` Klasse 20 Zahlen im Wertebereich von 1 - 100. Schreibe eine Funktion `NumberInfos` die folgendes ausgibt:

    - Die niedrigste und höchste Zahl
    - Die Summe aller Zahlen
    - Den Durchschnitt aller Zahlen
    - Das Aggregate mit einer Multiplikation aller Zahlen

4. Das Erste und Letzte Element

    Gib mit der Funktion `SelectFruits` aus der Liste mit Früchten,

    - die erste Frucht, die mit "b" beginnt
    - die letzte Frucht, die mit "g" beginnt
    - die Frucht die mit "y" beginnt oder den Default Wert

    aus.

    ```csharp
    string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape", "strawberry", "blackberry", "gooseberry", "blueberry", "raspberry" };
    ```

5. Sortieren und Gruppieren

    Implementiere die Funktion `SortAndGroupFruits` welche die folgenden Aufgaben erfüllen soll:

    - Sortiere die Früchte alphabetisch
    - Gruppiere die Früchte nach dem ersten Buchstaben und gibt die Anzahl der Früchte pro Buchstabe aus

6. Listen verknüpfen

    Implementiere die Funktion `JoinLists`, welche die zwei unten stehen Listen verknüpft. Hierbei soll es sich um einen klassichen "INNER JOIN" handeln. Bedeutet in diesem Fall: Mitarbeiter die keine gültige Abteilung haben, werden am Ende nicht mit ausgegeben.

    Das Ziel ist es eine Liste von Mitarbeitername und dem Abteilungsnamen auszugeben.

    ```csharp
    (int id, string name)[] departments = { (1, "Backoffice"), (2, "Development"), (3, "Sales") };
    
    (string Name, int departmentID)[] employees = {
             ("Peter Pan", 2),
             ("Max Mustermann", 1),
             ("Hugo Müller", 2),
             ("Petra Schmidt", 3),
             ("Hans Ludwig", 3),
             ("Georg Kaiser", 4)
        };
    ```

7. Partitionierung

    Implementiere die Funktion `SkipAndTake`, welche zwei Aufgaben erfüllt:

    - Erstelle eine Liste aus der unten vorgegeben List und überspringe alle Einträge die kleiner 5 sind.
    - Erstelle aus der unten vorgegeben Liste eine Liste mit den ersten 3 Einträgen

    ```csharp
    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    ```

8. Selektieren und umwandeln

    Implementieren eine Funktion `SelectAndTransform` die zwei Aufgaben hat.

    1. Runde die Zahlen des folgenden Arrays ab und gibt die aus.

    ```csharp
    decimal[] numbers = { 3.4M, 8.33M, 5.225M };
    ```

    2. Berechne aus den unten angegebenen Winkeln Cosinus und Sinus. Erzeuge daraus einen anonymen Rückgabetype und gibt die Wert aus.

    ```csharp
    double[] angles = { 30, 60, 90 };
    ```

9. Prüfen ob Element in einer Liste enthalten sind

    Implementiere die Funktion `DetectElements` und setze folgendes um:

    - Prüfe ob in der Liste irgendein Name ist, der mit B beginnt.
        ```csharp
        string[] names = { "Bob", "Ned", "Amy", "Bill" };
        ```
    - Prüfe ob die Liste 5 Einträge enthält
        ```csharp
        int[] numbers = { 1, 3, 5, 7, 9 };
        ```

## TimeTracking erweitern

Es ist Zeit unser Wissen über Dictionaries, Generics und Link zu nutzen und die Zeitverwaltung zu erweitern.

1. Umbau auf TimeSpan

    `TimeSpan` ist eine Möglichkeit einen Zeitwert zu speichern und später sehr einfach damit rechnen zu können. Wir bauen unser Record `TimeEntry` von `double` auf `TimeSpan` um.

2. Mehrere Einträge pro Tag und Mitarbeiter

    Wir erweitern die Funktion `AddTimeEntry` in der Logik, damit wir nun auch mehrere `TimeEntry` Einträge pro Mitarbeiter und Tag speichern können. Dazu können wir das Dictionary behalten, wir müssen es nur etwas umbauen.

3. Zeit pro Mitarbeiter und Tag ausgeben

    Wir bennen die Funktion `GetTimeEntries` um in `GetTotalWorkingHours` und setzten zwei Parameter (`Employee` für den Mitarbeiter und `DateTime` für den Tag den wir auslesen wollen). Die Funktion ermittelt aus dem Dictionary die Gesamtstunden für den angegeben Mitarbeiter und den angegeben Tag und gibt diese aus.

    Die Ausgabe soll z.B. bei 7 Stunden und 52 Minuten als `string` wie folgt formatiert ausgegeben werden: `7:52`;

4. Zeit pro Mitarbeiter und in einer Zeitspanne ausgeben

    Implementiere eine Überladung der Funktion `GetTotalWorkingHours` welche die Zeit pro Mitarbeiter und in einer Zeitspanne ausgibt. Die Funktion soll folgende Parameter haben:

    - `Employee` für den Mitarbeiter
    - `DateTime` für den Start des Zeitraums
    - `DateTime` für das Ende des Zeitraums

    Die Ausgabe soll im gleichen Format, wie in der vorherigen Aufgabe ausgegeben werden.

## Ressourcen

[LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)

[Random](https://docs.microsoft.com/en-us/dotnet/api/system.random?view=net6.0)

[Patterns / Operations](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching)

[Math](https://docs.microsoft.com/en-us/dotnet/api/system.math?view=net6.0)

[TimeSpan](https://docs.microsoft.com/de-de/dotnet/api/system.timespan?view=net6.0)
