# Attributes und Async/Await

## Async /Await

Berechne die folgende Methode in einer asynchronen Aufgabe und warte auf das Ergebnis:

```csharp
static double ComputePi()
{
    var sum = 0.0;
    var step = 1e-9;
    for (var i = 0; i < 1000000000; i++)
    {
        var x = (i + 0.5) * step;
        sum = sum + 4.0 / (1.0 + x * x);
    }
    return sum * step;
}
```

Führe diese Berechnung 5 mal aus und vergleiche die Zeit (mit `Stopwatch`)

- Bei einer synchronen Ausführung
- Bei einer parallel asynchronen Ausführung

Für die asynchrone Abarbeitung erstellst du eine leere `List<Task>` und fügst in einer Schleife die erzeugten Schleie 5 mal den Task in die Liste hinzu.

Danach wartest du mit `Task.WaitAll` darauf, das die Tasks alle ausgeführt wurden.

Vergleiche die Zeiten!

## Asynchrone Web API Aufrufe

Erstelle einen Konsolenanwendung die eine asynchrone Methode `GetWeather` enthält und das Wetter für die als Parameter übergebene Stadt abruft.

Um das Wetter für eine Stadt abzurufen, könnt ihr den folgenden Service nutzen: https://goweather.herokuapp.com/weather/leipzig

Die REST API liefert ein JSON mit aktuellen Informationen zum Wetter zurück. 

Um so eine REST API abzufragen, benötigt ihr die Klasse `HttpClient` und die Methode `GetAsync`.

Prüft ob das Ergbnis erfolgreich war, ansonsten werft ihr eine `Exception`.

Sollte der Call zu REST API erfolgreich sein, so könnt ihr das Ergebnis mit der Methode `ReadAsStringAsync` auf dem Content des Response Objekts auslesen. 

Dann müsst ihr noch mit `JsonConvert.DeserializeObject<T>` euer JSON in ein Objekt konvertieren. Dieses Objekt müsst ihr vorher als `record` oder `class` definieren.

Ruft die Methode `GetWeather` aus eurer `Main` Methode auf und gebt das Ergebnis aus.

## Attribute einsetzen

Du sollst für die folgende Klasse Attribute entwickeln und einsetzen. Bei der Klasse handelt es sich um eine Entität die in einer Datenbank gespeichert wird und im Frontend in einem Editor angezeigt und bearbeitet wird.

Der hier angesprochene Editor im Frontend, ist  rein fiktional und soll nur als Beispiel dienen.

```csharp
public class Person
{
    public string Name { get; set; }

    public string Address { get; set; }

    public string ReferenceId { get; set; }

    public void Save()
    {
        // TODO: Implement save logic here (not your job today ;))
    }
}
```

1. Entwickle das Attribut `Editable`, welches du auf die Klasse anwenden kannst. Dieses Attribut gibt Auskunft darüber, ob die Klasse bearbeitet werden darf. Sie bekommt keine Parameter übergeben. Wenn das Attribute nicht auf der Klasse gesetzt ist, wird ein Objekt der Klasse im Editor nicht bearbeitet werden können.

2. Entwickle ein Attribute `Multiline`, welches einen `int` Parameter mit der Anzahl von Zeilen übergeben bekommt, die der Editor später darstellen soll. Wende es auf das Property `Address` an.

3. Entwickle ein Attribute `Internal`, welches keine Parameter übergeben bekommt. Wende es auf das Property `ReferenceId` an. Dieses Property soll nicht im Editor angezeigt und bearbeitet werden können.

4. Entwickle ein Attribute `EntityReference`, welches einen `string` Parameter mit dem Namen der Entität übergeben bekommt. Der Name der Entität, soll die den Tabellennamen in der DB wiederspiegeln. Wende es auf die Methode `Save` an. Damit wird ausgedrückt, in welche Tabelle die Entität gespeichert werden soll.

5. Lese die Attribute von einer Instanz der Klasse `Person` aus.

## Ressourcen

[Stopwatch](https://docs.microsoft.com/de-de/dotnet/api/system.diagnostics.stopwatch?view=net-6.0)

[Async](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/concepts/async/)

[Await](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/keywords/await)

[Wait.All](https://docs.microsoft.com/de-de/dotnet/api/system.threading.tasks.task.waitall?view=net-6.0)

[HttpClient](https://docs.microsoft.com/de-de/dotnet/api/system.net.http.httpclient?view=net-6.0)

[Benutzerdefinierte Attribute erstellen](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/concepts/attributes/creating-custom-attributes)

[Zugriff auf Attribute](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/concepts/attributes/accessing-attributes-by-using-reflection)