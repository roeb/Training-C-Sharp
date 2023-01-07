# ADO.NET - Datenbankzugriff mit C#

Wir arbeiten in den folgenden Übungen mit der AdventureWorks SQL Datenbank. Die AdventureWorks Datenbank ist eine Beispiel Datenbank die ein fiktives, multinationales Industrieunternehmen namens Adventure Works Cycles abbildet.

> Solltest du dich im Umgang mit T-SQL nicht sicher fühlen, findest du in den [Hinweisen](./Hints.md) die benötigten SQL Statements. 
> 
> Versuche jedoch nach Möglichkeit die SQL Statements selbst zu schreiben.

## Verbindung zur Datenbank herstellen und Daten abfragen

Erstelle eine Consolen Anwendung und füge die NuGet Pakete `System.Data.SqlClient` hinzu. Die Anwendung soll alle Kunden, die mindestens eine Bestellung ausgeführt haben, laden und diese in der Konsole ausgeben. 

Zum laden der Kunden kann z.B. der `SqlDataReader` zum Einsatz kommen.

Anhand der Eingabe der `CustomerID`, soll es möglich sein, die Bestellungen des Kunden zu laden. Es soll die Lieferanschrift und die bestellten Artikel angezeigt werden.

Versuche beim laden der Details der Bestellung den `SqlDataAdapter` und/oder den `SqlDataReader` zu verwenden.

Achte bei der Umsetzung der Aufgabe darauf, das du die Datenbankenverbindungen korrekt aufbaust und auch wieder beendets (Hinweis: `using` nutzen).

## Speichern eines neuen Produktes

Nun sollst du deiner Anwendung die Möglichkeit geben, neue Produkte anzulegen und erstellte Produkte zu löschen.

Damit du ein ein Produkt erstellen kannst, muss der Benutzer die folgenden Informationen eingeben:

    - Name des Produktes
    - Produktnummer
    - Preis
    - Produktkategorie (Findest du in der Tabelle ProductCategory)

> Hinweis: die Kategorien kannst du über die folgende Funktion laden: 
>
> `SELECT * FROM dbo.ufnGetAllCategories()`

Prüfe nach dem Anlegen des Produktes, ob es in der Datenbank vorhanden ist.

## Löschen eines Produktes

Nun ist es an der Zeit, das du die angelegten Produkte auch wieder entfernen kannst.

Durch eine die Eingabe der Produktnummer, soll es möglich sein, das Produkt zu löschen.

Prüfe danach, ob das Produkt aus der Datenbank entfernt wurde.

## Ressourcen

[ConnectionString](https://connectionstrings.com/sql-server/)

[SqlConnection](https://docs.microsoft.com/de-de/dotnet/api/system.data.sqlclient.sqlconnection?view=dotnet-plat-ext-6.0)

[SqlCommand](https://docs.microsoft.com/de-de/dotnet/api/system.data.sqlclient.sqlcommand?view=dotnet-plat-ext-6.0)

[SqlDataReader](https://docs.microsoft.com/de-de/dotnet/api/system.data.sqlclient.sqldatareader?view=dotnet-plat-ext-6.0)

[DataTable](https://docs.microsoft.com/de-de/dotnet/api/system.data.datatable?view=dotnet-plat-ext-6.0)

[DataSet](https://docs.microsoft.com/de-de/dotnet/api/system.data.dataset?view=dotnet-plat-ext-6.0)


