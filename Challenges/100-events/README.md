# Delegates und Events

## Delegate

1. ***Delegate deklarieren und implementieren**
    In dieser Übung hast du die Aufgabe einen Delegate zum deklarieren, der eine Zeichenkette als Parameter entgegennimmt und eine Zeichenkette zurückgibt.

    Dazu sollst du einen Methode implementieren, von dem Delegate ausgeführt wird. Die Aufgabe der Methode ist es, die Zeichenkette in Großbuchstaben umzuwandeln und zurückzugeben.

    Führe den Delegate aus.

2. **Aufbau einer Delegate Kette (Multicasting Delegates)**

    Entwickle zwei weitere Methoden, die auf die Signatur des Delegates passen.

    - Die erste Methode ersetzt die Leerzeichen im String durch Bindestriche.
    - Die zweite Methode ersetzt alle **T** in der Zeichenkette durch **7**

    Sorge dafür die Zeichenkette als `ref` übergeben wird, damit die Änderungen durch die Delegate Kette übernommen werden.

## Events

Zum Start findest du ein Teil des Codes hier: **Challenges/100-events/start/02_Events**.

In der Übung ist bereits eine Klasse `Product` implementiert und wird im `Main` erzeugt.

Deine Aufgabe ist es ein Event zu implementieren, welches ein Delegate zurückgibt, wenn die Methode `Sell` aufgerufen wird.

Du musst nun für deine `Product` Instanz einen EventHandler implementieren und diesen an das Event `ProductSold` binden.

Der EventHandler hat folgende Aufgaben:

- Prüfen ob das Produkt noch verfügbar ist (Status != Ordered) und wenn nicht, eine Meldung ausgeben. Der Verkaufsprozess ist damit beendet.
- Prüfen ob das Produkt, wenn es verfügbar ist, in der gewünschten Menge verfügbar ist. Wenn nicht, eine Meldung ausgeben und den Status auf **Ordered** setzen. Der Verkaufsprozess ist damit beendet.
- Wenn das Produkt in ausreichender Menge verfügbar ist, wird eine Meldung ausgegeben und der Lagerbestand aktualisiert.

## Countdown

Zum Start findest du ein Teil des Codes hier: **Challenges/100-events/start/03_Countdown**.

Schreibe ein Countdown-Alarmprogramm, das Delegates verwendet, um alle Interessierten darüber zu informieren, dass die festgelegte Zeitspanne abgelaufen ist.

Du benötigen eine Klasse, um die Countdown-Uhr zu simulieren, die eine Nachricht akzeptiert, und eine Anzahl von Sekunden die abzuwarten sind (Soll vom Benutzer eingegeben werden). 

Nachdem die entsprechende Zeit gewartet wurde, sollte die Countdown-Uhr den Delegate anrufen und die Nachricht an alle registrierten Subscripter weiterleiten. (Wenn du die Wartezeit berechnest, denke daran, dass `Thread.Sleep()`ein Argument in Millisekunden benötigt wird und eine `using System.Threading`Anweisung erforderlich ist.) 

Erstelle auch eine Observer Klasse, die die empfangene Nachricht an die Konsole zurückgibt.

## Ressourcen

[String: Zeichenkette verändern](https://learn.microsoft.com/de-de/dotnet/csharp/how-to/modify-string-contents)

[String: Großbuchstaben umwandeln](https://learn.microsoft.com/de-de/dotnet/api/system.string.toupper?view=net-6.0)

[Delegate](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/delegates/)

[Delegates verwenden](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/delegates/using-delegates)

[Events implementieren](https://learn.microsoft.com/de-de/dotnet/csharp/programming-guide/events/how-to-publish-events-that-conform-to-net-framework-guidelines)

[Events abonnieren](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events)