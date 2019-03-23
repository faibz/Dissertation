using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace CSharpTester.Tests
{
    public class PrimitiveTests
    {
        [ClrJob(true), CoreJob, MonoJob]
        [RPlotExporter, RankColumn, JsonExporter("List-Primitive")]
        public class ListTests
        {
            public IList<int> List { get; set; } = new List<int>();

            [Params(1, 10, 1000, 10_000_000)]
            public int Count { get; set; }

            private readonly Random _random = new Random();
            private int _index;

            [GlobalSetup]
            public void Setup()
            {
                _index = _random.Next(Count);

                for (var i = 0; i < Count; i++)
                {
                    List.Add(i);
                }
            }

            [Benchmark]
            public void IndexRetrieval()
            {
                var res = List[_index];
            }

            [GlobalCleanup]
            public void Cleanup()
            {
                List.Clear();
            }
        }

        [ClrJob(true), CoreJob, MonoJob]
        [RPlotExporter, RankColumn, JsonExporter("Array-Primitive")]
        public class ArrayTests
        {
            public int[] Array { get; set; }

            [Params(1, 10, 1000, 10_000_000)]
            public int Count { get; set; }

            private readonly Random _random = new Random();
            private int _index;

            [GlobalSetup]
            public void Setup()
            {
                Array = new int[Count];
                _index = _random.Next(Count);

                for (var i = 0; i < Count; i++)
                {
                    Array[i] = i;
                }
            }

            [Benchmark]
            public void IndexRetrieval()
            {
                var res = Array[_index];
            }

            [GlobalCleanup]
            public void Cleanup()
            {
                Array = null;
            }
        }

        [ClrJob(true), CoreJob, MonoJob]
        [RPlotExporter, RankColumn, JsonExporter("Queue-Primitive")]
        public class QueueTests
        {
            public Queue<int> Queue { get; set; } = new Queue<int>();

            [Params(1, 10, 1000, 10_000_000)]
            public int Count { get; set; }

            [Benchmark]
            public void Enqueue()
            {
                for (var i = 0; i < Count; i++)
                {
                    Queue.Enqueue(i);
                }
            }

            [Benchmark]
            public void Dequeue()
            {
                for (var i = 0; i < Count; i++)
                {
                    Queue.Dequeue();
                }
            }
        }

        [ClrJob(true), CoreJob, MonoJob]
        [RPlotExporter, RankColumn, JsonExporter("Stack-Primitive")]
        public class StackTests
        {
            public Stack<int> Stack { get; set; } = new Stack<int>();

            [Params(1, 10, 1000, 10_000_000)]
            public int Count { get; set; }

            [Benchmark]
            public void Push()
            {
                for (var i = 0; i < Count; i++)
                {
                    Stack.Push(i);
                }
            }

            [Benchmark]
            public void Pop()
            {
                for (var i = 0; i < Count; i++)
                {
                    Stack.Pop();
                }
            }
        }

        [ClrJob(true), CoreJob, MonoJob]
        [RPlotExporter, RankColumn, JsonExporter("Dictionary-Primitive")]
        public class DictionaryTests
        {
            public IDictionary<int, int> Dictionary { get; set; } = new Dictionary<int, int>();

            [Params(1, 10, 1000, 10_000_000)]
            public int Count { get; set; }

            private readonly Random _random = new Random();
            private int _key;

            [GlobalSetup]
            public void Setup()
            {
                _key = _random.Next(Count);

                for (var i = 0; i < Count; i++)
                {
                    Dictionary.Add(i, i);
                }
            }

            [Benchmark]
            public void KeyLookup()
            {
                var res = Dictionary[_key];
            }

            [GlobalCleanup]
            public void Cleanup()
            {
                Dictionary.Clear();
            }
        }

        [ClrJob(true), CoreJob, MonoJob]
        [RPlotExporter, RankColumn, JsonExporter("LinkedList-Primitive")]
        public class LinkedListTests
        {
            public LinkedList<int> LinkedList { get; set; } = new LinkedList<int>();

            [Params(1, 10, 1000, 10_000_000)]
            public int Count { get; set; }

            private readonly Random _random = new Random();
            private int _find;

            [Benchmark]
            public void Add()
            {
                _find = _random.Next(Count);

                for (var i = 0; i < Count; i++)
                {
                    LinkedList.AddFirst(i);
                }
            }

            [Benchmark]
            public void Find()
            {
                var res = LinkedList.Find(_find);
            }

            [Benchmark]
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
