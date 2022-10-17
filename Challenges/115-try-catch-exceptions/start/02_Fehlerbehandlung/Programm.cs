using System;

class Program
{
    static void Main(string[] args)
    {
        ErrorHandling.HandleErrorByThrowingException();

        Console.ReadKey();
    }
}

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}