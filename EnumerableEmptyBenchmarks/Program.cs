using System;
using BenchmarkDotNet.Running;

namespace EnumerableEmptyBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[] {
                    typeof(ExecuteBenchmarks),
                });
            switcher.Run(args);
        }

    }
}
