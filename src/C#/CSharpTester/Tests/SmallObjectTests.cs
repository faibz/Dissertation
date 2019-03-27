using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using CSharpTester.Objects;

namespace CSharpTester.Tests
{
    public class SmallObjectTests
    {
        [ClrJob(true), CoreJob, MonoJob]
        [RankColumn, JsonExporter("List-SmallObject")]
        public class ListTests
        {
            public IList<SmallObject> List { get; set; } = new List<SmallObject>();
            private readonly SmallObject _object = new SmallObject();

            [Params(1, 10, 1000, 10000)]
            public int Count { get; set; }

            private readonly Random _random = new Random();
            private int _index;

            [GlobalSetup]
            public void Setup()
            {
                _index = _random.Next(Count);

                for (var i = 0; i < Count; i++)
                {
                    List.Add(_object);
                }
            }
        
            [Benchmark]
            public object IndexRetrieval()
            {
                return List[_index];
            }
        
            [GlobalCleanup]
            public void Remove()
            {
                List.Clear();
            }
        }

        [ClrJob(true), CoreJob, MonoJob]
        [RankColumn, JsonExporter("Array-SmallObject")]
        public class ArrayTests
        {
            public SmallObject[] Array { get; set; }
            private readonly SmallObject _object = new SmallObject();

            [Params(1, 10, 1000, 10000)]
            public int Count { get; set; }

            private readonly Random _random = new Random();
            private int _index;

            [GlobalSetup]
            public void Setup()
            {
                Array = new SmallObject[Count];
                _index = _random.Next(Count);

                for (var i = 0; i < Count; i++)
                {
                    Array[i] = _object;
                }
            }

            [Benchmark]
            public object IndexRetrieval()
            {
                return Array[_index];
            }

            [GlobalCleanup]
            public void Cleanup()
            {
                Array = null;
            }
        }

        [ClrJob(true), CoreJob, MonoJob]
        [RankColumn, JsonExporter("Queue-SmallObject")]
        public class QueueTests
        {
            public Queue<SmallObject> Queue { get; set; } = new Queue<SmallObject>();
            private readonly SmallObject _object = new SmallObject();

            [Params(1, 10, 1000, 10000)]
            public int Count { get; set; }

            [Benchmark]
            public void EnqueueAndDequeue()
            {
                for (var i = 0; i < Count; i++)
                {
                    Queue.Enqueue(_object);
                }

                for (var i = 0; i < Count; i++)
                {
                    Queue.Dequeue();
                }
            }
        }

        [ClrJob(true), CoreJob, MonoJob]
        [RankColumn, JsonExporter("Stack-SmallObject")]
        public class StackTests
        {
            public Stack<SmallObject> Stack { get; set; } = new Stack<SmallObject>();
            private readonly SmallObject _object = new SmallObject();

            [Params(1, 10, 1000, 10000)]
            public int Count { get; set; }

            [Benchmark]
            public void PushAndPop()
            {
                for (var i = 0; i < Count; i++)
                {
                    Stack.Push(_object);
                }

                for (var i = 0; i < Count; i++)
                {
                    Stack.Pop();
                }
            }
        }

        [ClrJob(true), CoreJob, MonoJob]
        [RankColumn, JsonExporter("Dictionary-SmallObject")]
        public class DictionaryTests
        {
            public IDictionary<int, SmallObject> Dictionary { get; set; } = new Dictionary<int, SmallObject>();
            private readonly SmallObject _object = new SmallObject();

            [Params(1, 10, 1000, 10000)]
            public int Count { get; set; }

            private readonly Random _random = new Random();
            private int _key;

            [GlobalSetup]
            public void Setup()
            {
                _key = _random.Next(Count);

                for (var i = 0; i < Count; i++)
                {
                    Dictionary.Add(i, _object);
                }
            }

            [Benchmark]
            public object KeyLookup()
            {
                return Dictionary[_key];
            }

            [GlobalCleanup]
            public void Cleanup()
            {
                Dictionary.Clear();
            }
        }
    }
}
