# Operator Overloading

## Operator Overloading

Du findest den Code zum Starten in **Challenges/160-member-overloading/start/01_OperatorOverloading**.

Die Zentralbank erwägt die Einführung des US-Dollars als zweite Währung, daher müssen alle Buchhaltungssysteme angepasst werden, um mehrere Währungen zu handhaben.

Du wurdest gebeten, das Währungsbetragsobjekt zu implementieren.

1. Aktiviere den auf Gleichheit zu prüfenden Währungsbetrag

    Bitte änder die `CurrencyAmount` Struktur, um die Gleichheit zu behandeln. Wenn die beiden Währungsbetragsstrukturen nicht dieselbe Währung haben ("USD" oder "EUR"), sollte eine `ArgumentException` ausgelöst werden.

    ```csharp
    CurrencyAmount amountA = new CurrencyAmount(55, "EUR");
    CurrencyAmount amountB = new CurrencyAmount(55, "EUR");
    CurrencyAmount amountC = new CurrencyAmount(55, "USD");

    amountA == amountB
    // => true
    amountA != amountB
    // => false
    amountA == amountC
    // => ArgumentException
    amountA != amountC
    // => ArgumentException
    ```

2. Währungsbeträge vergleichen

    Bitte ändere die `CurrencyAmount` Struktur, um Vergleiche zu verarbeiten ( nur `>` und `<`). Wenn die beiden Währungsbetragsstrukturen nicht dieselbe Währung haben ("USD" oder "EUR"), soll eine `ArgumentException` ausgelöst werden.

    ```csharp
    CurrencyAmount amountA = new CurrencyAmount(55, "EUR");

    amountA > new CurrencyAmount(50, "EUR")
    // => true
    amountA < new CurrencyAmount(50, "EUR")
    // => false
    amountA > new CurrencyAmount(50, "USD")
    // => ArgumentException
    ```

3. Währungsbeträge addieren und subtrahieren

    Bitte ändere die `CurrencyAmount` Struktur, um arithmetische Additionen und Subtraktionen zu handhaben ( nur `+` und `-`). Wenn die beiden Währungsbetragsstrukturen nicht dieselbe Währung haben ("USD" oder "HD"), soll eine `ArgumentException` ausgelöst werden.

    ```csharp
    CurrencyAmount amountA = new CurrencyAmount(55, "EUR");
    CurrencyAmount amountB = new CurrencyAmount(100, "EUR");
    CurrencyAmount amountC = new CurrencyAmount(55, "USD");

    amountA + amountB
    // => {155, EUR}
    amountB - amountA
    // => {45, EUR}
    amountA + amountC
    // => ArgumentException
    ```

4. Multipliziere und dividiere Währungsbeträge

    Bitte ändere die `CurrencyAmount` Struktur, um arithmetische Multiplikation und Division ( nur `*` und `/`) zu verarbeiten.

    ```csharp
    CurrencyAmount amountA = new CurrencyAmount(10, "EUR");

    amountA * 2m
    // => {20, EUR}
    amountA / 2m
    // => {5, EUR}
    ```

5. Wandel den Währungsbetrag in ein Doppeltes um

    Bitte ändere die `CurrencyAmount` Struktur so, dass eine Instanz explizit in eine `double` gecastet werden kann.

    ```csharp
    CurrencyAmount amountA = new CurrencyAmount(55.5m, "EUR");

    (double)amountA
    // => 55.5d
    ```

6. Wandel den Währungsbetrag in eine Dezimalzahl um

    Bitte ändere die `CurrencyAmount` Struktur so, dass eine Instanz implizit in eine `decimal`konvertiert werden kann.

    ```csharp
    CurrencyAmount amountA = new CurrencyAmount(55.5m, "HD");
    decimal d = amountA;
    // => d == 55.5m
    ```

## dynamic

Das XML für diese Aufgabe findet ihr unter: https://csharptraining.blob.core.windows.net/files/book.xml

Lade in ein `XDocument` das XML von oben und gibt in einer Schleife folgende Informationen der `book` Elemente aus:

- Titel
- PublishingDate
- Price

```csharp
XDocument doc = XDocument.Load("https://csharptraining.blob.core.windows.net/files/book.xml");

foreach(var book in doc.Document.Element("catalog").Elements("book"))
{
    Console.WriteLine($"Title: {book.Element("title").Value}; Price: {book.Element("price").Value} Euro; Released: {book.Element("publish_date").Value}");
}
```

Baue die Logik so um, das du ein `dynamic` Objekt hast und dort direkt in der Laufzeit auf die Felder zugreifen kannst.

Dazu musst du zuerst das NuGet Package "Newtonsoft.Json" installieren (siehe Ressourcen).

Danach kannst du das `XDocument` in ein `json` konvertieren und das wiederum in ein `dynamic` Objekt.

```csharp
string jsonText = JsonConvert.SerializeXNode(doc);
dynamic dynXml = JsonConvert.DeserializeObject<ExpandoObject>(jsonText);
```

Greife nun direkte auf das `dynXml` Objekt zu und gib die Informationen aus. 

```csharp
string title = dynXml.catalog.book[0].title
```

Ersetze deine Schleife mit der `dynamic` Implementierung.

## Ressourcen

[Operator Overloading](https://learn.microsoft.com/de-de/dotnet/csharp/language-reference/operators/operator-overloading)

[Visual Studio NuGet](https://docs.microsoft.com/de-de/nuget/quickstart/install-and-use-a-package-in-visual-studio)

[ExpandoObject](https://docs.microsoft.com/de-de/dotnet/api/system.dynamic.expandoobject?view=net-6.0)