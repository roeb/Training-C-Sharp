using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    const int EXECUTIONSCOUNT = 5;

    static void Main(string[] args)
    {
        var watch = Stopwatch.StartNew();

        for (int i = 0; i < EXECUTIONSCOUNT; i++)
        {
            var pi = ComputePi();
            Console.WriteLine($"[{i}]: ComputePi() executed: {pi}");
        }

        watch.Stop();
        Console.WriteLine($"{EXECUTIONSCOUNT} synchron ComputePi() Executions finished in {watch.Elapsed.TotalSeconds} sec");

        watch.Restart();

        var tasks = new List<Task>();
        for (int i = 0; i < EXECUTIONSCOUNT; i++)
        {
            var piTask = ComputePiAsync(i);
            tasks.Add(piTask);
        }

        Task.WaitAll(tasks.ToArray());

        watch.Stop();
        Console.WriteLine($"{EXECUTIONSCOUNT} asynchron ComputePi() Executions finished in {watch.Elapsed.TotalSeconds} sec");

        Console.ReadKey();
    }

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

    static Task<double> ComputePiAsync(int index)
    {
        return Task.Factory.StartNew(() => {
            var pi = ComputePi();

            Console.WriteLine($"[{index}]: ComputePi() executed: {pi}");

            return pi;
        });
    }
}
