using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace EnumerableEmptyBenchmarks
{
    [MemoryDiagnoser]
    public class ExecuteBenchmarks
    {
        [Benchmark(Baseline = true)]
        public void EmptyStruct()
        {
            var empty = MyEnumerable.EmptyStruct<int>();
            var enumerator = empty.GetEnumerator();
            enumerator.MoveNext();
        }

        [Benchmark]
        public void EmptyDisposableStruct()
        {
            var empty = MyEnumerable.EmptyDisposableStruct<int>();
            using(var enumerator = empty.GetEnumerator())
            {
                enumerator.MoveNext();
            }
        }

        [Benchmark]
        public void EmptyClass()
        {
            var empty = MyEnumerable.EmptyClass<int>();
            using(var enumerator = empty.GetEnumerator())
            {
                enumerator.MoveNext();
            }
        }

        [Benchmark]
        public void LinqEmpty()
        {
            var empty = System.Linq.Enumerable.Empty<int>();
            using(var enumerator = empty.GetEnumerator())
            {
                enumerator.MoveNext();
            }
        }    
    }
}