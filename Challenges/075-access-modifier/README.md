# Vererbung, Structs und Zugriffsmodifizierer

## Vererbung

Eine abstrakte Klasse `Zeit` soll eine Variable vom Typ `DateTime` und zwei Konstruktoren besitzen. 

Ein parameterloser Konstruktor dient dazu, die aktuelle Zeit des Computers zu ermitteln (`DateTime.Now`) und die Variable damit zu initialisieren. 

Dem zweiten Konstruktor kann eine beliebige Zeit übergeben werden.

Die Klasse definiert außerdem die abstrakte Methode `ZeitAnzeige()`.

Leite von dieser Klasse zwei Klassen (`ZeitKurz` und `ZeitLang`) ab, welche die abstrakte Methode überschreiben. 

Die Methode der Klasse `ZeitKurz` soll die Zeit ohne Sekunden zurückgeben. 

Die der Klasse `ZeitLang` mit Angabe der Sekunden. 

Verwende dazu die Methoden `ToShortTimeString()` bzw. `ToLongTimeString()` des `DateTime`-Objekts. 

## Zauberer und Krieger (Vererbung)

In dieser Übung spielst du ein Rollenspiel namens „Wizard and Warriors“, bei dem du entweder als Zauberer oder als Krieger spielen kannst.

Es gibt unterschiedliche Regeln für Krieger und Zauberer, um zu bestimmen, wie viele Schadenspunkte sie austeilen.

Für einen Krieger gelten folgende Regeln:

- Füge 6 Schadenspunkte zu, wenn der angegriffene Charakter nicht verwundbar ist
- Füge 10 Schadenspunkte zu, wenn der angegriffene Charakter verwundbar ist

Für einen Zauberer gelten folgende Regeln:

- Füge 12 Schadenspunkte zu, wenn der Zauberer einen Zauber im Voraus vorbereitet hat
- Füge 3 Schadenspunkte zu, wenn der Zauberer keinen Zauber im Voraus vorbereitet hat

Im Allgemeinen sind Charaktere niemals verwundbar. Zauberer sind jedoch verwundbar, wenn sie keinen Zauber vorbereitet haben.

1. Beschreibe einen Charakter

    Überschreibe die `ToString()` Methode in der `Character` Klasse, um eine Beschreibung des Zeichens im Format "Character is a <CHARACTER_TYPE>".

    ```csharp
    var warrior = new Warrior();
    warrior.ToString();
    // => "Character is a Warrior"
    ```

2. Charaktere standardmäßig nicht verwundbar machen

    Stelle Sie sicher, dass die `Character.Vulnerable()`Methode immer zurückgibt false.

    ```csharp
    var warrior = new Warrior();
    warrior.Vulnerable();
    // => false
    ```

3. Lasse die Wizards einen Zauber vorbereiten

    Implementiere die `Wizard.PrepareSpell()` Methode, damit ein Zauberer einen Zauber im Voraus vorbereiten kann.

    ```csharp
    var wizard = new Wizard();
    wizard.PrepareSpell();
    ```

4. Zauberer verwundbar machen, wenn sie keinen Zauber vorbereitet haben

    Stelle sicher, dass die `Vulnerable()` Methode `true` zurückgibt, wenn der Zauberer keinen Zauber vorbereitet hat; andernfalls kommt `false` zurück.

    ```csharp
    var wizard = new Wizard();
    wizard.Vulnerable();
    // => true
    ```

5. Berechne die Schadenspunkte für einen Zauberer

    Implementiere die `Wizard.DamagePoints()` Methode, um die zugefügten Schadenspunkte zurückzugeben: 
    
    - 12 Schadenspunkte, wenn ein Zauberspruch vorbereitet wurde
    - 3 Schadenspunkte, wenn nicht

    ```csharp
    var wizard = new Wizard();
    var warrior = new Warrior();

    wizard.PrepareSpell();
    wizard.DamagePoints(warrior);
    // => 12
    ```

6. Berechne die Schadenspunkte für einen Krieger

    Implementiere die `Warrior.DamagePoints()` Methode, um die zugefügten Schadenspunkte zurückzugeben: 
    - 10 Schadenspunkte, wenn das Ziel verwundbar ist
    - 6 Schadenspunkte, wenn es nicht verwundbar ist

    ```csharp
    var warrior = new Warrior();
    var wizard = new Wizard();

    warrior.DamagePoints(wizard);
    // => 10
    ```

## Structs

Wir wollen mit Hilfe von Structs die Grenzen von Grundstücken modellieren. Ein Grundstück (`Plot`) besteht aus 4 Punkten (`Claim`), welche die Grenzen des Grundstücks definieren.

- Erstelle je ein Struct für `Plot` und `Claim`.
- Ein `Claim`Struct hat 2 Eigenschaften: `X` und `Y`. Diese werden per Konstruktur initialisiert. 
- `Plot` bekommt im Konstruktor 4 `Claim` Objekte übergeben.

## Taschenrechner

Wir bauen unseren Taschenrechner etwas stabiler und nutzen im Zuge der OOP die Vererbung.

Jede Rechenoption (addieren, multiplizieren, dividieren) leitet von der Basisklasse `CalculateOperation` ab, die über folgendes verfügt:

Achte bitte auf die richtige Verwendung der Zugriffoperatoren `public`, `protected` und `private`.

- Name der Operator
- Einen Konstruktor der zwei Werte übergibt.
- Eine Funktion `Execute()` welche die Berechnung durchführt.
- Eine Funktion `Result()` die in der Lage ist die Berechnung in einem Wortlauf wiederzugeben (Addition von 10 und 12 ergibt 22).