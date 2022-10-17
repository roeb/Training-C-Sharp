# Abschlussprojekt: Tic-Tac-Toe

## Aufgabenstellung

Schreibe ein Konsolenprogramm, mit dem zwei Spieler [Tic Tac Toe] spielen können.

Mit Programmstart beginnt ein neues Spiel, das sich so darstellt:

```bash
 A B C 
0 | | 
 -+-+-  
1 | | 
 -+-+-  
2 | | 

Kommando:
```

Die Spieler ziehen im Wechsel, indem sie die Koordinaten des Feldes als Kommando eingeben, auf den sie ihren Spielstein setzen wollen, z.B. „A0“ oder „C2“. Das Symbol des Spielsteins von Spieler 1 ist „X“, das für Spieler 2 ist „O“.

Platziert ein Spieler seinen Stein auf einem schon gefüllten Feld, wird das Spielbrett nochmals ohne Veränderung angezeigt. Der Spieler darf es nochmals versuchen.

Nach jedem Zug wird das Spielbrett neu angezeigt. Wenn Spieler 1 nach A0 zieht und dann Spieler 2 nach B1, sieht das Spielbrett so aus:

```bash
 A B C 
0X| | 
 -+-+-  
1 |O| 
 -+-+-  
2 | | 

Kommando:
```

Um ein neues Spiel zu beginnen, wird „neu“ statt einer Spielfeldkoordinate eingegeben.

Um das Programm zu verlassen, wird „ende“ als Kommando eingegeben.

Ein Spiel endet, wenn kein weiterer Zug mehr möglich ist oder ein Spieler gewonnen hat. Eine entsprechende Meldung wird angezeigt, z.B.

```bash
 A B C 
0X| | 
 -+-+-  
1X|O|O 
 -+-+-  
2X| | 

*** Spieler 1 gewinnt

Kommando:
```

Ist ein Spiel beendet, werden nur noch die Kommandos „neu“ und „ende“ interpretiert.

## Ressourcen

[TicTacToe](https://de.wikipedia.org/wiki/TicTacToe)