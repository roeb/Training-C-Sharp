# Interfaces, Enums und Generics

## Interfaces

Du sollst mit einer Anwendung Lottoziehungen simulieren. 

Dazu werden die Ziehungen **5 aus 35** und **6 aus 49** implementiert.

Definiere ein Interface `ILotto`, welche die Methoden `GetLottoZahl(int maxZahl)` und `GetAnzahl()` enthält. 

Die erste Methode liefert eine Zufallszahl im Bereich von **0 bis maxZahl**. In dieser Übung sind doppelte Zahlen in der Ziehung erlaubt. 

Die zweite Methode liefert die Anzahl der zu ziehenden Zahlen, also **5** oder **6**. Diese Methoden sollen unter anderem von den Klassen `Lotto5Aus35` und `Lotto6Aus49` implementiert werden.

> Zum Erzeugen von Zufallszahlen verwende die Klasse `Random` aus dem Namespace `System`. 
> 
> Die Methode `Next(int n)` liefert dazu einen `int`-Wert zwischen `0 und n-1`.
> ```csharp
>Random rd = new Random(); 
>int i = rd.Next(35) + 1;
>```

## Wettbewerb mit Remote Cars

Ein Versuchswagen wurde entwickelt und die Teststrecke muss angepasst werden, um sowohl Serien- als auch Versuchsmodelle zu handhaben. 

Die Auto legen pro Race eine unterschiedliche Strecke zurück. Das Versuchsmodell schafft nur 20 Meter, wo hingegen das Serienmodell 10 Meter zurücklegt (pro Aufruf von `Race()`).

1. Ermögliche, dass Autos auf derselben Teststrecke gefahren werden können.

    Bitte füge der `IRemoteControlCar` Schnittstelle eine Methode hinzu, um die Implementierungen `Drive()` für die beiden Autotypen verfügbar zu machen.

    Bei `TestTrack` handelt es sich um eine statische Klasse mit statischen Funktionen.

    ```csharp
    TestTrack.Race(new ProductionRemoteControlCar());
    TestTrack.Race(new ExperimentalRemoteControlCar());
    ```

2. Ermögliche den Vergleich der zurückgelegten Strecke verschiedener Modelle auf der Teststrecke

    Bitte füge der `IRemoteControlCar`Schnittstelle eine Eigenschaft hinzu, um die Implementierungen der `DistanceTravelled` Eigenschaft für die beiden Autotypen verfügbar zu machen.

    ```csharp
    var prod = new ProductionRemoteControlCar();
    TestTrack.Race(prod);
    var exp = new ExperimentalRemoteControlCar();
    TestTrack.Race(exp);
    prod.DistanceTravelled
    // => 10
    exp.DistanceTravelled
    // => 20
    ```

## Enums: Logging, Logging & Logging!

In dieser Übung verarbeitest du Protokollzeilen.

Jede Protokollzeile ist eine Zeichenfolge, die wie folgt formatiert ist: 
    
```
[<LVL>]: <MESSAGE>
```

Dies sind die verschiedenen Protokollebenen:

- TRC (trace)
- DBG (debug)
- INF (info)
- WRN (warning)
- ERR (error)
- FTL (fatal)

1. Analysiere die Protokollebene

    Definiere eine `LogLevel`Aufzählung mit sechs Elementen, die den oben genannten Protokollebenen entsprechen.

    - Trace
    - Debug
    - Info
    - Warning
    - Error
    - Fatal

    Implementiere als Nächstes die Methode (`static`) `LogLine.ParseLogLevel()`, um die Protokollebene einer Protokollzeile zu analysieren:

    ```csharp
    LogLine.ParseLogLevel("[INF]: File deleted")
    // => LogLevel.Info
    ```

2. Unterstützung unbekannter Protokollebene

    Leider haben gelegentlich einige Protokollzeilen eine unbekannte Protokollebene. Um diese Protokollzeilen ordnungsgemäß zu handhaben, füge der Aufzählung `LogLevel` ein `UnknownElement` hinzu,  das zurückgegeben werden sollte, wenn eine unbekannte Protokollebene analysiert wird:

    ```csharp
    LogLine.ParseLogLevel("[XYZ]: Overly specific, out of context message")
    // => LogLevel.Unknown
    ```

3. Protokollzeile in Kurzformat umwandeln

    Die Protokollebene einer Protokollzeile ist ziemlich ausführlich. Um den zum Speichern der Protokollzeilen benötigten Speicherplatz zu reduzieren, wurde ein kurzes Format entwickelt: 

    ```
    [<ENCODED_LEVEL>]:<MESSAGE>
    ```

    Die codierte Protokollebene ist eine einfache Zuordnung einer Protokollebene zu einer Zahl:

    - Unknown-0
    - Trace-1
    - Debug-2
    - Info-4
    - Warning-5
    - Error-6
    - Fatal-42

    Implementiere die (statische) `LogLine.OutputForShortLog()` Methode, die das verkürzte Protokollzeilenformat ausgeben kann:

    ```csharp
    LogLine.OutputForShortLog(LogLevel.Error, "Stack overflow")
    // => "6:Stack overflow"
    ```

## Generics

Deine Aufgabe ist es, einen Generische Klasse `Descriper<T>` zu schreiben, wo bei `T` dann ein bliebiger Datentyp ist.

Der Konstruktor der Klasse soll einen Parameter vom Typ `T` entgegennehmen, welcher einem Wert entspricht (bei `int` z.B. 4) und diesen in einer privaten Eigenschaft speichern.

Ebenso soll der Konstruktor eine weitere Eigenschaft vom Typ `string` entgegennehmen, welche ebenfalls in einer privaten Eigenschaft gespeichert wird und die Beschreibung des Wertes darstellt. ("Anzahl der Ecken eines Rechtecks").

Die Klasse soll die Methode `ToString()` überschreiben und folgendes zurück geben: 
```csharp
return $"{_description}: {_value}";
```

Implementiere nun noch zwei öffentliche Eigenschaften, welche den Wert und die Beschreibung zurück geben, aber von außerhalb der Klasse nicht gesetzt werden können.

Nun kannst du die Methode `GetValueType()` implementieren, welche den Datentyp des Wertes zurück gibt.

## Taschenrechner

Erweitere deinen Taschenrechner um ein Enum `Operation`, welche die vier Rechenoperationen abbildet. Ersetze in `CalculateOperation` für die Eigenschaft `Operation`, den `string` durch dein Enum.

> Du kannst einem Enum Wert ein `char` zuweisen, das macht die Konvertierung später leichter
> ```csharp
> public enum Operation {
>    Addition = '+'
> }
> ```

Erzeuge eine statische Klasse `Calculator` welche mit der Methode `Execute` die passende Implementierung von `CalculateOperation` zurück gibt. Als Parameter übergibtst du die Operation und die beiden Werte.

**Bonus:** Erzeuge ein eigenes Struct `OperationValues` mit den beiden Rechenwerten und übergib dieses als Parameter an die Methode `Execute`, anstelle der beiden einzelnen Werte.

Interface: Calculator mit allen Operationen
Enum: Operationen

## Ressourcen

[Interfaces](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/interfaces/)

[Enum](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/builtin-types/enum)

[Generics](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/generics/)

[Struct](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/classes-and-structs/structs)