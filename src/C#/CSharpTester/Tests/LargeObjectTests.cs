using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using CSharpTester.Objects;

namespace CSharpTester.Tests
{
    public class LargeObjectTests
    {
        [ClrJob(true), CoreJob, MonoJob]
        [RankColumn, JsonExporter("List-LargeObject")]
        public class ListTests
        {
            public IList<LargeObject> List { get; set; } = new List<LargeObject>();
            private readonly LargeObject _object = new LargeObject();

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
            public LargeObject[] Array { get; set; }
            private readonly LargeObject _object = new LargeObject();

            [Params(1, 10, 1000, 10000)]
            public int Count { get; set; }

            private readonly Random _random = new Random();
            private int _index;

            [GlobalSetup]
            public void Setup()
            {
                Array = new LargeObject[Count];
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
        [RankColumn, JsonExporter("Queue-LargeObject")]
        public class QueueTests
        {
            public Queue<LargeObject> Queue { get; set; } = new Queue<LargeObject>();
            private readonly LargeObject _object = new LargeObject();

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
        [RankColumn, JsonExporter("Stack-LargeObject")]
        public class StackTests
        {
            public Stack<LargeObject> Stack { get; set; } = new Stack<LargeObject>();
            private readonly LargeObject _object = new LargeObject();

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
            public IDictionary<int, LargeObject> Dictionary { get; set; } = new Dictionary<int, LargeObject>();
            private readonly LargeObject _object = new LargeObject();

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

        [ClrJob(true), CoreJob, MonoJob]
        [RankColumn, JsonExporter("LinkedList-Primitive")]
        public class LinkedListTests
        {
            public LinkedList<LargeObject> LinkedList { get; set; } = new LinkedList<LargeObject>();
            private readonly LargeObject _object = new LargeObject();

            [Params(1, 10, 1000, 10000)]
            public int Count { get; set; }

            [GlobalSetup]
            public void Add()
            {
                for (var i = 0; i < Count; i++)
                {
                    LinkedList.AddLast(_object);
                }
            }

            [Benchmark]
            public object Find()
            {
                return LinkedList.FindLast(_object);
            }

            [GlobalCleanup]
            public void Remove()
            {
                for (var i = 0; i < Count; i++)
                {
                    LinkedList.RemoveLast();
                }
            }
        }
    }
}
