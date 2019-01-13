using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using CSharpTester.Objects;

namespace CSharpTester.Tests
{
    public class SmallObjectTests
    {
        [ClrJob(true), CoreJob, MonoJob]
        [RPlotExporter, RankColumn, JsonExporter("List-SmallObject")]
        public class ListTests
        {
            public IList<SmallObject> List { get; set; } = new List<SmallObject>();
            private readonly SmallObject _object = new SmallObject();

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
                    List.Add(_object);
                }
            }
        
            [Benchmark]
            public void IndexRetrieval()
            {
                var res = List[_index];
            }
        
            [GlobalCleanup]
            public void Remove()
            {
                List.Clear();
            }
        }

        [ClrJob(true), CoreJob, MonoJob]
        [RPlotExporter, RankColumn, JsonExporter("Array-SmallObject")]
        public class ArrayTests
        {
            public SmallObject[] Array { get; set; }
            private readonly SmallObject _object = new SmallObject();

            [Params(1, 10, 1000, 10_000_000)]
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

        //        [ClrJob(true), CoreJob, MonoJob, CoreRtJob]
        //        [RPlotExporter, RankColumn, JsonExporter("Hashset-SmallObject")]
        //        public class HashsetTests
        //        {
        //            public HashSet<SmallObject> Collection { get; set; } = new HashSet<SmallObject>();
        //            private readonly SmallObject _object = new SmallObject(0, 'a');
        //
        //            [Benchmark]
        //            public void Add()
        //            {
        //                for (var i = 0; i < 100_000_000; i++)
        //                {
        //                    Collection.Add(_object);
        //                }
        //            }
        //
        //            [Benchmark]
        //            public void Contains()
        //            {
        //                for (var i = 0; i < 100_000_000; i++)
        //                {
        //                    Collection.Add(_object);
        //                }
        //            }
        //
        //            [Benchmark]
        //            public void Remove()
        //            {
        //                Collection.Remove(_object);
        //            }
        //        }

        [ClrJob(true), CoreJob, MonoJob]
        [RPlotExporter, RankColumn, JsonExporter("Queue-SmallObject")]
        public class QueueTests
        {
            public Queue<SmallObject> Queue { get; set; } = new Queue<SmallObject>();
            private readonly SmallObject _object = new SmallObject();

            [Params(1, 10, 1000, 10_000_000)]
            public int Count { get; set; }

            [Benchmark]
            public void Enqueue()
            {
                for (var i = 0; i < Count; i++)
                {
                    Queue.Enqueue(_object);
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
        [RPlotExporter, RankColumn, JsonExporter("Stack-SmallObject")]
        public class StackTests
        {
            public Stack<SmallObject> Stack { get; set; } = new Stack<SmallObject>();
            private readonly SmallObject _object = new SmallObject();

            [Params(1, 10, 1000, 10_000_000)]
            public int Count { get; set; }

            [Benchmark]
            public void Push()
            {
                for (var i = 0; i < Count; i++)
                {
                    Stack.Push(_object);
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
        [RPlotExporter, RankColumn, JsonExporter("Dictionary-SmallObject")]
        public class DictionaryTests
        {
            public IDictionary<int, SmallObject> Dictionary { get; set; } = new Dictionary<int, SmallObject>();
            private readonly SmallObject _object = new SmallObject();

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
                    Dictionary.Add(i, _object);
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
    }
}
