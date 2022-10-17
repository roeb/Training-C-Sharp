# Enumerations & Nullable

## Nullable

In dieser Übung schreibst du Code zum Drucken von Namensschildern für Fabrikmitarbeiter.

Ausgangspunkt:
```csharp
static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        throw new NotImplementedException("Please implement the (static) Badge.Print() method");
    }
}
```

1. Drucke einen Ausweis für einen Mitarbeiter

    Mitarbeiter haben eine ID, einen Namen und einen Abteilungsnamen. 
    
    Mitarbeiterausweisetiketten sind wie folgt formatiert: "[id] - name - DEPARTMENT". 
    
    Implementiere die `Badge.Print()` Methode, um das Ausweisetikett eines Mitarbeiters zurückzugeben:

    ```csharp
    Badge.Print(734, "Ernest Johnny Payne", "Strategic Communication");
    // => "[734] - Ernest Johnny Payne - STRATEGIC COMMUNICATION"
    ```

2. Drucke einen Ausweis für einen neuen Mitarbeiter

    Aufgrund einer Macke im Computersystem haben neue Mitarbeiter manchmal noch keinen Ausweis, wenn sie in der Fabrik anfangen zu arbeiten. 
    
    Da Ausweise erforderlich sind, erhalten sie einen temporären Ausweis ohne das ID-Präfix.
    
    Ändere die `Badge.Print()` Methode, um neue Mitarbeiter zu unterstützen, die noch keine ID haben:

    ```csharp
    Badge.Print(id: null, "Jane Johnson", "Procurement");
    // => "Jane Johnson - PROCUREMENT"
    ```

3. Drucke einen Ausweis für den Eigentümer aus

    Auch der Fabrikbesitzer muss immer eine Plakette tragen. Ein Eigentümer hat jedoch keine Abteilung. 
    
    In diesem Fall sollte das Etikett `"OWNER"` anstelle des Abteilungsnamens gedruckt werden. 
    
    Ändere die `Badge.Print()` Methode, um ein Etikett für den Besitzer zu drucken:

    ```csharp
    Badge.Print(254, "Charlotte Hale", department: null);
    // => "[254] - Charlotte Hale - OWNER"
    ```

    Beachte, dass der Eigentümer auch ein neuer Mitarbeiter sein kann:

    ```csharp
    Badge.Print(id: null, "Charlotte Hale", department: null);
    // => "Charlotte Hale - OWNER"
    ```

## Lists

Du findest den Code zum Starten in **Challenges/125-nullable/start/02_Lists**.

In dieser Übung schreibst du Code, um eine Liste von Programmiersprachen zu verfolgen, die du in Übungen lernen möchten.

Du hast neun Aufgaben, die alle den Umgang mit Listen beinhalten.

1. Erstelle eine neue Liste

    Um den Überblick über die Sprachen zu behalten, die du lernen möchten, musst du eine neue Liste erstellen.

    Implementiere die statische `Languages.NewList()` Methode, die eine neue, leere Liste zurückgibt.

    ```csharp
    Languages.NewList()
    // => empty list
    ```

2. Definiere eine vorhandene Liste

    Derzeit hast du ein Blatt Papier, auf dem die Sprachen aufgeführt sind, die du lernen möchtest: C#, Clojure und Elm.

    Bitte implementiere die statische `Languages.GetExistingLanguages()` Methode, um die Liste zurückzugeben.

    ```csharp
    Languages.GetExistingLanguages();
    // => {"C#", "Clojure", "Elm"}
    ```

3. Füge einer Liste eine neue Sprache hinzu

    Wenn du weitere interessante Sprachen findest, möchtest du diese zu deiner Liste hinzufügen.

    Implementiere die statische `Languages.AddLanguage()` Funktion, um eine neue Sprache am Ende der Liste hinzuzufügen.

    ```csharp
    Languages.AddLanguage(Languages.GetExistingLanguages(), "VBA");
    // => {"C#", "Clojure", "Elm", "VBA"}
    ```

4. Zähle die Sprachen in der Liste

    Es ist unpraktisch, die Sprachen einzeln zu zählen.

    Implementiere die statische `Languages.CountLanguages()` Methode, um die Anzahl der Sprachen auf deiner Liste zu zählen.

    ```csharp
    Languages.CountLanguages(Languages.GetExistingLanguages())
    // => 3
    ```

5. Überprüfe ob eine Sprache in der Liste enthalten ist

    Implementiere  die statische `Languages.HasLanguage()` Methode, um zu prüfen, ob eine Sprache vorhanden ist.

    ```csharp
    Languages.HasLanguage(Languages.GetExistingLanguages(), "Elm")
    // => true
    ```

6. Kehre die Liste um

    Irgendwann stellst du fest, dass deine Liste eigentlich rückwärts geordnet ist!

    Implementiere die statische `Languages.ReverseList()` Methode, um deine Liste umzukehren.

    ```csharp
    Languages.ReverseList(Languages.GetExistingLanguages())
    // => {"Elm", "Clojure", "C#"}
    ```

7. Überprüfe ob die Liste spannend ist

    Während du alle Sprachen liebst, hat C# einen besonderen Platz in Ihrem Herzen. Daher freust du dich wirklich über eine Liste mit Sprachen, wenn:

    - Der erste auf der Liste ist C# oder
    - Das zweite Element auf der Liste ist C#, und die Liste enthält entweder zwei oder drei Sprachen.

    Implementiere die statische `Languages.IsExciting()` Methode, um zu prüfen, ob eine Liste von Sprachen spannend ist:

    ```csharp
    Languages.IsExciting(Languages.GetExistingLanguages())
    // => true
    ```

8. Sprache entfernen

    Bitte implementiere die statische `Languages.RemoveLanguage()` Methode, um eine bestimmte Sprache aus der Liste zu entfernen.

    ```csharp
    Languages.RemoveLanguage(Languages.GetExistingLanguages(), "Clojure")
    // => { "C#", "Elm" }
    ```

9. Überprüfe ob alle Sprachen in der Liste eindeutig sind

    Bitte implementiere die statische `Languages.IsUnique()` Methode, um zu prüfen, ob sich eine der Sprachen in der Liste wiederholt.

    Die Liste der Sprachen ist garantiert nicht leer, wenn diese Methode aufgerufen wird, und es spielt keine Rolle, ob die Liste geändert wird.

    ```csharp
    Languages.IsUnique(Languages.GetExistingLanguages())
    // => true
    ```

## Dictionaries

Du findest den Code zum Starten in **Challenges/125-nullable/start/03_Dictionaries**.

In dieser Übung schreibst du Code, um internationale Vorwahlen über ein Dictionary verfolgen.

Das Dictionary verwendet eine Ganzzahl für seine Schlüssel (die Vorwahl) und eine Zeichenfolge (Landesname) für seine Werte.

Du hast 9 Aufgaben, die die `DialingCodes` Klasse betreffen.

1. Erstelle ein neues Dictionary

    Implementiere die Methode `DialingCodes.GetEmptyDictionary()`, die ein leeres Dictionary zurückgibt.

    ```csharp
    DialingCodes.GetEmptyDictionary();
    // => empty dictionary
    ```

2. Erstelle ein vorab ausgefülltes Dictionary

    Es gibt ein vorbelegtes Dictionary, das die folgenden 3 Vorwahlen enthält: 
    
    - „Vereinigte Staaten von Amerika“ mit einer Vorwahl von 1, 
    - „Brasilien“ mit einer Vorwahl von 55  
    - „Indien“ mit einer Vorwahl von 91. 
    
    Implementiere die `DialingCodes.GetExistingDictionary()` Methode, um das vorab ausgefüllte Dictionary zurückzugeben:

    ```csharp
    DialingCodes.GetExistingDictionary();
    // => 1 => "United States of America", 55 => "Brazil", 91 => "India"
    ```

3. Füge einem leeren Dictionary ein Land hinzu

    Implementiere die Methode `DialingCodes.AddCountryToEmptyDictionary()`, die ein Dictionary erstellt und ihm eine Vorwahl und den zugehörigen Ländernamen hinzufügt.

    ```csharp
    DialingCodes.AddCountryToEmptyDictionary(44, "United Kingdom");
    // => 44 => "United Kingdom"    
    ```

4. Füge einem bestehenden Wörterbuch ein Land hinzu

    Implementiere die Methode `DialingCodes.AddCountryToExistingDictionary()`, die einem nicht leeren Dictionary eine Vorwahl und den zugehörigen Ländernamen hinzufügt.

    ```csharp
    DialingCodes.AddCountryToExistingDictionary(DialingCodes.GetExistingDictionary(),
    44, "United Kingdom");
    // => 1 => "United States of America", 44 => "United Kingdom", 55 => "Brazil", 91 => "India"
    ```

5. Rufe den Ländernamen ab, der einer Vorwahl entspricht

    Implementiere die Methode `DialingCodes.GetCountryNameFromDictionary()`, die eine Vorwahl nimmt und den entsprechenden Ländernamen zurückgibt. Wenn die Vorwahl nicht im Dictionary enthalten ist, wird eine leere Zeichenfolge zurückgegeben.

    ```csharp
    DialingCodes.GetCountryNameFromDictionary(
    DialingCodes.GetExistingDictionary(), 55);
    // => "Brazil"

    DialingCodes.GetCountryNameFromDictionary(
    DialingCodes.GetExistingDictionary(), 999);
    // => string.Empty
    ```

6. Überprüfe ob ein Land im Wörterbuch vorhanden ist

    Implementiere die Methode `DialingCodes.CheckCodeExists()`, um zu prüfen, ob eine Vorwahl im Dictionary vorhanden ist.

    ```csharp
    DialingCodes.CheckCodeExists(DialingCodes.GetExistingDictionary(), 55);
    // => true  
    ```

7. Aktualisiere einen Ländernamen

    Implementiere die Methode `DialingCodes.UpdateDictionary()`, die eine Vorwahl entgegennimmt und den entsprechenden Ländernamen im Dictionary durch den als Parameter übergebenen Ländernamen ersetzt. Wenn die Vorwahl nicht im Dictionary vorhanden ist, bleibt das Dictionary unverändert.

    ```csharp
    DialingCodes.UpdateDictionary(
    DialingCodes.GetExistingDictionary(), 1, "Les États-Unis");
    // => 1 => "Les États-Unis", 55 => "Brazil", 91 => "India"

    DialingCodes.UpdateDictionary(
    DialingCodes.GetExistingDictionary(), 999, "Newlands");
    // 1 => "United States of America", 55 => "Brazil", 91 => "India"
    ```

8. Entferne ein Land aus dem Dictionary

    Implementiere die Methode `DialingCodes.RemoveCountryFromDictionary()`, die eine Vorwahl nimmt und den entsprechenden Datensatz, Vorwahl + Ländername, aus dem Dictionary entfernt.

    ```csharp
    DialingCodes.RemoveCountryFromDictionary(
    DialingCodes.GetExistingDictionary(), 91);
    // => 1 => "United States of America", 55 => "Brazil"
    ```

9. Finde das Land mit dem längsten Namen

    Implementiere die Methode `DialingCodes.FindLongestCountryName()`, die den Namen des Landes mit dem längsten im Wörterbuch gespeicherten Namen zurückgibt.

    ```csharp
    DialingCodes.FindLongestCountryName(
    DialingCodes.GetExistingDictionary());
    // => "United States of America"
    ```

## Taschenrechner

Nun ist es an der Zeit, das du mit deinem Wissen über Listen, in deinem Taschenrechner eine Historie implementierst.

Immer wenn eine Rechenaktion durchgeführt wurde, wird die in einer Liste folgende Information gespeichert:
    - Operation
    - Operand 1 und Operand 2
    - Ergebnis

Nutze hierfür eine Liste und erzeuge dir eine Klasse, die der Struktur deiner Historie entspricht.

Erweitere den Taschenrechner um folgende Funktionalität:

- Es kann fortlaufend gerechnet werden. Beim start benötigt er zwei Operanden. Danach wird der aktuelle Wert mit einem Operanden oder einem Operator kombiniert. 
- Nach jeder Rechenoperation wird das Ergebnis in der Historie gespeichert.
- Es muss möglich sein, die den aktuellen Wert aus dem `Calculator` auszulesen
- Nach jeder Operation kann der Nutzer entscheiden ob das Programm beenden oder eine weitere Operation durchführen möchte.

## Ressourcen

[Nullable](https://learn.microsoft.com/de-de/dotnet/csharp/language-reference/builtin-types/nullable-value-types)

[List](https://learn.microsoft.com/de-de/dotnet/api/system.collections.generic.list-1?view=net-6.0)

[Dictionary](https://learn.microsoft.com/de-de/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0)