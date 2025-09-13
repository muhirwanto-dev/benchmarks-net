using BenchmarkDotNet.Running;

namespace Fundamentals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The BenchmarkSwitcher will find all benchmark classes in the current assembly
            // and run them based on the provided command-line arguments.
            // If no arguments are provided, it will list all available benchmarks.
            // https://benchmarkdotnet.org/articles/guides/console-args.html
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
