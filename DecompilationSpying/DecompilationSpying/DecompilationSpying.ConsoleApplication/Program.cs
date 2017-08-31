using System;
using System.Diagnostics;

namespace DecompilationSpying.ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sw = new Stopwatch();
            var mc = new AsyncSleepyMethods();
            sw.Start();

            var s = mc.CallSleepyComplicatedAwaiting().Result;
            Console.WriteLine(s);
            Console.WriteLine($"sw:{sw.ElapsedMilliseconds}");
            sw.Restart();

            ///////////////////////////////////////////////
            sw.Stop();

            Console.WriteLine("ready all");
            Console.ReadKey();
        }
    }
}