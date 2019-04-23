using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Object = CSharpTester.Objects.Object;

namespace CSharpTester.Tests
{
    public class ObjectTests
    {
        [ClrJob(true), CoreJob, MonoJob]
        [RankColumn, JsonExporter("List-Object")]
        public class ListTests
        {
            public IList<Object> List { get; set; } = new List<Object>();
            private readonly Object _object = new Object();

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
        [RankColumn, JsonExporter("Queue-Object")]
        public class QueueTests
        {
            public Queue<Object> Queue { get; set; } = new Queue<Object>();
            private readonly Object _object = new Object();

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
        [RankColumn, JsonExporter("Stack-Object")]
        public class StackTests
        {
            public Stack<Object> Stack { get; set; } = new Stack<Object>();
            private readonly Object _object = new Object();

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
        [RankColumn, JsonExporter("Dictionary-Object")]
        public class DictionaryTests
        {
            public IDictionary<int, Object> Dictionary { get; set; } = new Dictionary<int, Object>();
            private readonly Object _object = new Object();

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
        [RankColumn, JsonExporter("LinkedList-Object")]
        public class LinkedListTests
        {
            public LinkedList<Object> LinkedList { get; set; } = new LinkedList<Object>();
            private readonly Object _object = new Object();
            private readonly Object _targetObject = new Object {CharProperty = 'b', IntProperty = 1};

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
                return LinkedList.FindLast(_targetObject);
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
