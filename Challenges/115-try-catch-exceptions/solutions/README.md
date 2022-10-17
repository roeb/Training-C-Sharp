# Lambdas & Fehlerbehandlung

## Lambda Expressions - Grundlagen

```csharp
public string GetFullName(string firstName, string lastName) => $"{firstName} {lastName}";
```

```csharp
public class Foo
{
    private readonly string _name;

    public Foo(string name) => _name = name;
}
```

```csharp
public string CheckSpeed(int speed) => speed switch
{
    < 50 => "Zu langsam",
    >=50 and <= 55 => "OK",
    >55 and < 70 => "Zu schnell",
    _ => "Viel zu schnell"
};
```

## Die Wetterstation (Lambdas)

Die Lösung findest du unter **Challenges/115-try-catch-exceptions/solutions/01_Lambdas**.

## Fehlerbehandlung

Die Lösung findest du unter **Challenges/115-try-catch-exceptions/solutions/02_Fehlerbehandlung**.

## Benutzerdefinierte Ausnahme

Die Lösung findest du unter **Challenges/115-try-catch-exceptions/solutions/03_Custom_Exceptions**.

## Bank Account

Die Lösung findest du unter **Challenges/115-try-catch-exceptions/solutions/04_Bank_Account**.

## Taschenrechner

Die Lösung findest du unter **Challenges/115-try-catch-exceptions/solutions/05_Calc_Iteration_05**.