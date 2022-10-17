# Arrays, null, Modifikator und Auswahlbedingungen

## Arbeiten mit Arrays

1. Erstelle ein Array, das zwei ganzzahlige Werte beinhalten kann.

2. Schreibe in das erste Felde des Arrays die Zahl 11 und in das zweite Feld die Zahl 22.

3. Erstelle ein Array vom Typ `string`, belege es bereits bei der Initialisierung mit den Werten `"Hallo"` und `"Welt"`. Arbeite hierbei mit dem variablen Typ `var`.

4. Erzeuge ein Array und fülle es mit 100 Zahlen. Nutze hierfür eine `for` Schleife.

5. Kopiere das Arrays aus Aufgabe 4 (Copy Befehl) und ersetze alle ungeraden Zahlen mit dem Wert `0`.
Gibt danach das Array mit den geraden Zahlen aus, aber nur die, die nicht `0` sind.

## Methoden und Modifikatoren

1. Schreibe eine Methode für eine Zahl, die die Zahl als Potenz von 2 zurückgibt, wenn sie negativ ist, oder als Quadratwurzel, wenn sie positiv oder Null ist.
    ```csharp
    NegativeOrPositive(-2) → 4
    NegativeOrPositive(6.25) → 2.5
    ```

2. Schreiben Sie eine Methode, die jeden Buchstaben 'y' in der Zeichenkette durch 'x' ersetzt. Angenommen, die Zeichenkette enthält nur Kleinbuchstaben. Nutze hier bitte nicht die `Replace` Methode von `string`, sondern arbeite mit Schleifen und Bedingungen.
    > Mit `"dein string".Split(' ')` kannst du einen String in ein Array von Strings aufteilen und erhältst ein Array mit den einzelnen Wörtern.
    ```csharp
    ReplaceXWithY("yeeeeah") → "xeeeeah"
    ReplaceXWithY("auto") → "auto"
    ```

3. Schreiben Sie eine Methode für eine Zeichenkette mit mindestens zwei durch Leerzeichen getrennten Wörtern, die das erste Wort in der Zeichenkette in Großbuchstaben, das zweite in Kleinbuchstaben und so weiter ändert. Nutze hierfür den Rückgabetyp `void` und gebe das Ergebnis durch eine `out` Parameter zurück.
    ```csharp
    ToLowerOrToUpper("da ist das ding", out string result);
    result → "DA ist DAS ding"
    ```

## Switch und Überladungen von Methoden

Entwickele ein System, das den Mitarbeitern der Website eines Fußball-/Fußballklubs hilft, über Spiele zu berichten. Dieses System ist in der Lage, verschiedene Aspekte des Spiels auf und neben dem Spielfeld zu analysieren und sie in einen Ereignisstrom umzuwandeln.

1. Beschreibungen der Spieler anhand ihrer Trikotnummer ausgeben

    Das Team spielt immer nur in einer 4-3-3-Formation und hat der Änderung der Regeln von 1965, die Auswechslungen erlaubt, geschweige denn erweiterte Kader, nie zugestimmt.

    Die Spielerbeschreibungen lauten wie folgt:
    ```
    1 -> "goalie"
    2 -> "left back"
    3 & 4 "center back"
    5 -> "right back"
    6, 7 & 8 -> "midfielder"
    9 -> "left wing"
    10 -> "striker"
    11 -> "right wing"
    ```

    Implementiere die statische `PlayAnalyzer.AnalyzeOnField()`Methode, um eine Spielerbeschreibung basierend auf ihrer Trikotnummer auszugeben.

    ```csharp
    PlayAnalyzer.AnalyzeOnField(10);
    // => "striker"
    ```

2. Erweitere die Abdeckung um Aktivitäten außerhalb des Feldes

    Implementiere das `PlayAnalyzer.AnalyzeOffField()`Verfahren, um Beschreibungen von Aktivitäten und Charakteren rund um das Spielfeld auszugeben. Diese Methode erhält verschiedene Arten von Daten, die analysiert und in geeigneten Text umgewandelt werden sollten, um den Journalisten zu helfen.

    Zu Beginn behandeln wir Daten über das Stadion:

    - Die aktuelle Anzahl der Fans im Stadion (beliebig int)
    - Durchsagen über das Lautsprecher-System des Stadions (beliebig string)

    Unbekannte Datentypen sollten nicht verarbeitet werden, wenn also die Methode Daten eines anderen Typs empfängt, soll ein Hinweis in der Konsole ausgegeben werden.

    ```csharp
    PlayAnalyzer.AnalyzeOffField(5000);
    // => "There are 5000 supporters at the match."

    PlayAnalyzer.AnalyzeOffField("5 minutes to go!");
    // => "5 minutes to go!"

    PlayAnalyzer.AnalyzeOffField(0.5);
    // => "Unbekannter Datentyp"
    ```

## Der Getränkeautomat

Wir entwickeln einen Getränkeautomat 🍻

1. Erstelle eine neue Konsolenanwendung.

2. Fordere den Nutzer auf einen Euro einzuwerfen. (1 Euro = "1" in der Eingabe)

3. Wenn der Nutzer einen Euro einwirft, dann gib ihm ein Bier aus. Ansonsten gib dem Nutzer den Hinweis aus, das es kein Getränk für diesen Einwurf gibt.

4. Erweitere den Automaten um weitere Getränke. (z.B. Cola, Fanta, Wasser, etc.) und gibt jeden Getränk einen anderen Preis.

5. Beim Starten des Programms kann der Nutzer als erstes zwischen den Getränken wählen (z.B. "1" für Bier, "2" für Cola, etc.). Danach kann er das Geld für das Getränke einwerfen.
    > Verwende für die Ausgabe des Preises `switch-case`, für die Prüfung des Betrages ein `if-else` Statement.

## Herausforderung: Maximum, Minimum, Mittelwert

> Zufallszahlen kannst du mit der `Random` Klasse erstellen. Mehr Infos, findest du hier: [Random](https://docs.microsoft.com/de-de/dotnet/api/system.random?view=net-6.0)

1. Erzeuge mit Hilfe der Klasse Random 10 ganzzahlige Zufallszahlen im Bereich zwischen 0 und 100 und geben Sie diese auf die Konsole aus.

2. Gebe **Maximum und Minimum** der obigen Arrays aus, ohne sie zu sortieren. Der Algorithmus soll dabei **nicht** auf den Bereich Bezug nehmen.

3. Gebe den **Mittelwert** der Zahlen des Arrays aus.

## Projekt: Taschenrechner

Wir bauen den Taschenrechner in der 2. Iteration aus. Wir werden nun unser Wissen bzgl. Bedingungen und Functionen nutzen können, um weitere Funktionalität bereitzustellen.

### Anforderungen

	* Überarbeitete die Softwarestruktur um eine höhere Wartbarkeit zu erreichen (Einsatz von Methoden)
	* Dividieren von Gleitkommazahlen
	* Multiplizieren von Gleitkommazahlen
	* Subtrahieren von Gleitkommazahlen
	* Addieren von Gleitkommazahlen

## Ressourcen
[Auswahlanweisungen](https://learn.microsoft.com/de-de/dotnet/csharp/language-reference/statements/selection-statements)
[Methoden](https://learn.microsoft.com/de-de/dotnet/csharp/programming-guide/classes-and-structs/methods)
[Konvertierung](https://learn.microsoft.com/de-de/dotnet/csharp/language-reference/language-specification/conversions#1032-explicit-numeric-conversions)
[Math](https://docs.microsoft.com/de-de/dotnet/api/system.math?view=net-6.0)
[String](https://docs.microsoft.com/de-de/dotnet/api/system.string?view=net-6.0)
[Modifizierer out](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/keywords/out-parameter-modifier)