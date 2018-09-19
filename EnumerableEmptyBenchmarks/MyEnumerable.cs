using System;
using System.Collections;
using System.Collections.Generic;

namespace EnumerableEmptyBenchmarks
{
    public static class MyEnumerable
    {
        public static EmptyEnumerableStruct<T> EmptyStruct<T>() => 
            new EmptyEnumerableStruct<T>();

        public static EmptyEnumerableDisposableStruct<T> EmptyDisposableStruct<T>() => 
            new EmptyEnumerableDisposableStruct<T>();

        public static IEnumerable<T> EmptyClass<T>() => 
            EmptyEnumerableClass<T>.Instance;

        public readonly struct EmptyEnumerableStruct<T>
        {   
            public EmptyEnumerableStruct<T> GetEnumerator() => 
                this;
                
            public T Current => default;

            public bool MoveNext() => false;
        }


        public readonly struct EmptyEnumerableDisposableStruct<T> : IEnumerable<T>, IEnumerator<T>
        {   
            public EmptyEnumerableDisposableStruct<T> GetEnumerator() => 
                this;
            
            IEnumerator<T> IEnumerable<T>.GetEnumerator() => 
                this;
            
            IEnumerator IEnumerable.GetEnumerator() => 
                this;
                
            public T Current => default;

            object IEnumerator.Current => default;

            public bool MoveNext() => false;

            public void Reset() { /* nothing to do */ }

            public void Dispose() { /* nothing to do */ }
        }

        public class EmptyEnumerableClass<T> : IEnumerable<T>, IEnumerator<T>
        {   
            static readonly EmptyEnumerableClass<T> instance = new EmptyEnumerableClass<T>();

            private EmptyEnumerableClass() { /* nothing to do */ }

            public static EmptyEnumerableClass<T> Instance => 
                instance;

            public IEnumerator<T> GetEnumerator() => 
                this;
            
            IEnumerator IEnumerable.GetEnumerator() => 
                this;
                
            public T Current => default;

            object IEnumerator.Current => default;

            public bool MoveNext() => false;

            public void Reset() { /* nothing to do */ }

            public void Dispose() { /* nothing to do */ }
        }    
    }
}