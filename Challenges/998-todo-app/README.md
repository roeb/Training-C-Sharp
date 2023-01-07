# Wiederholungsprojekt: Todo-App

Um unser Wissen wieder aufzufrischen, bauen wir eine Todo-App. Die App soll folgende Funktionalität bieten:

- Aufgaben hinzu- und entfernen
- Anzeigen aller Aufgaben
- Aufgabe als erledigt markieren
- Suchen von Aufgaben

## 1. Console App Project erstellen

Erstelle ein neues Console App Project mit dem Namen `TodoApp`. 

Wenn der Benutzer das Projekt startet, soll er informiert werden, welche Möglichkeiten und Befehle er hat.

Mögliche Befehle sind:

- `list`: Zeigt alle Aufgaben an
- `add <Aufgabe>`: Fügt eine neue Aufgabe hinzu
- `done <Aufgabennummer>`: Markiert eine Aufgabe als erledigt
- `remove <Aufgabennummer>`: Entfernt eine Aufgabe
- `search <Suchbegriff>`: Sucht nach einer Aufgabe
- `help`: Zeigt alle Befehle an
- `exit`: Beendet das Programm

Wenn der Benutzer den Befehl `help` eingibt, soll eine Liste mit allen Befehlen angezeigt werden.

Bei dem Befehl `exit` soll das Programm beendet werden.

Nach jedem eingebenen Befehl soll der Benutzer wieder aufgefordert werden, einen neuen Befehl einzugeben. Das Programm beendet sich erst, wenn der Benutzer den Befehl `exit` eingibt.

## 2. Anzeigen aller Aufgaben implementieren

Erstelle dir eine Klasse `ToDoManager`, welche die Methode `List` implementiert. 

Die Methode soll eine Liste von `ToDo`-Objekten zurückgeben, welche die folgenden Eigenschaften haben. 

- `Id`: Eindeutige Id der Aufgabe
- `Description`: Beschreibung der Aufgabe
- `IsDone`: Ob die Aufgabe erledigt ist

Implementiere den Befehel `list` in der `Program`-Klasse und rufe die `List`-Methode der `ToDoManager`-Klasse auf um alle **offenen** Aufgaben anzuzeigen. Es soll die `Id` und die `Description` ausgegeben werden.

Wenn noch keine Aufgaben in der Liste sind, soll der Benutzer darauf hingewiesen werden, das neue Aufgaben hinzugefügt werden können.

## 3. Hinzufügen einer Aufgabe implementieren

Füge der Klasse `ToDoManager` die Methode `Add` hinzu. Die Methode soll eine neue Aufgabe hinzufügen. Die Id der Aufgabe soll automatisch generiert werden und um ein höher als die bisher höchste Id sein.

Sollte eine Aufgabe mit der gleichen Bezeichnung bereits existieren, soll der Benutzer drauf hingewiesen und die Aufgabe nicht hinzugefügt werden.

Implementiere den Befehel `add` in der `Program`-Klasse und rufe die `Add`-Methode der `ToDoManager`-Klasse auf um eine neue Aufgabe hinzuzufügen.

Wenn die Aufgabe erfolgreich hinzugefügt wurde, soll der Benutzer die Möglichkeit haben, einen neuen Befehl einzugeben.

## 4. Aufgabe als erledigt markieren

Der Benutzer soll mit dem Befehl `done` eine Aufgabe als erledigt markieren können. Dazu muss er noch die Ìd` der Aufgabe angeben.

Implementiere in der Klasse `ToDoManager` die Methode `Done`. Die Methode soll die Aufgabe mit der angegebenen Id als erledigt markieren. 

Sollte keine Aufgabe mit der angegebenen Id gefunden werden, soll der Benutzer darauf hingewiesen werden.

### Bonus: Liste nach Status filtern

Erweitere den `list` Befehl um die Möglichkeit die Aufgaben nach ihren Status (erledigt oder nicht erledigt) zu filtern.

## 5. Löschen einer Aufgabe

Implementiere in der Klasse `ToDoManager` die Methode `Remove`. Die Methode soll die Aufgabe mit der angegebenen Id löschen.

Der Benutzer kann diese über den Befehl `remove` ausführen. Dazu muss er noch die Ìd` der Aufgabe angeben.

### Bonus: Persistieren der Aufgaben

Erweitere deine Applikation so, dass die Aufgaben in einer Datei gespeichert werden und beim Start auch wieder geladen werden.

## 6. Suchen von Aufgaben

Der Benutzer soll die Möglichkeit haben, nach Aufgaben in seiner Liste zu suchen. Dazu soll der Befehl `search` implementiert werden. Hier muss der Benutzer noch einen Suchbegriff angeben.

Implementiere in der Klasse `ToDoManager` die Methode `Search`. Die Methode soll alle Aufgaben zurückgeben, welche den Suchbegriff in der Beschreibung enthalten. 

Dem Benutzer soll neben der `Id` und `Description` der Aufgabe, auch noch der Status angezeigt werden.