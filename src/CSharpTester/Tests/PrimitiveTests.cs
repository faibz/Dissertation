using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace CSharpTester.Tests
{
    public class PrimitiveTests
    {
        [ClrJob(true), CoreJob, MonoJob, CoreRtJob]
        [RPlotExporter, RankColumn, JsonExporter("List-Primitive")]
        public class ListTests : ITestCollection
        {
            public IList<int> Collection { get; set; } = new List<int>();

            [Benchmark]
            public void Add()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Add(i);
                }
            }

            [Benchmark]
            public void Contains()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Contains(i);
                }
            }

            [Benchmark]
            public void Remove()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Remove(i);
                }
            }
        }

        [ClrJob(true), CoreJob, MonoJob, CoreRtJob]
        [RPlotExporter, RankColumn, JsonExporter("Hashset-Primitive")]
        public class HashsetTests : ITestCollection
        {
            public HashSet<int> Collection { get; set; } = new HashSet<int>();

            [Benchmark]
            public void Add()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Add(i);
                }
            }

            [Benchmark]
            public void Contains()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Contains(i);
                }
            }

            [Benchmark]
            public void Remove()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Remove(i);
                }
            }
        }

        [ClrJob(true), CoreJob, MonoJob, CoreRtJob]
        [RPlotExporter, RankColumn, JsonExporter("Queue-Primitive")]
        public class QueueTests : ITestCollection
        {
            public Queue<int> Collection { get; set; } = new Queue<int>();

            [Benchmark]
            public void Add()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Enqueue(i);
                }
            }

            [Benchmark]
            public void Contains()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Contains(i);
                }
            }

            [Benchmark]
            public void Remove()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Dequeue();
                }
            }
        }

        [ClrJob(true), CoreJob, MonoJob, CoreRtJob]
        [RPlotExporter, RankColumn, JsonExporter("Stack-Primitive")]
        public class StackTests : ITestCollection
        {
            public Stack<int> Collection { get; set; } = new Stack<int>();

            [Benchmark]
            public void Add()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Push(i);
                }
            }

            [Benchmark]
            public void Contains()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Contains(i);
                }
            }

            [Benchmark]
            public void Remove()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Pop();
                }
            }
        }

        [ClrJob(true), CoreJob, MonoJob, CoreRtJob]
        [RPlotExporter, RankColumn, JsonExporter("ArrayList-Primitive")]
        public class ArrayListTests : ITestCollection
        {
            public ArrayList Collection { get; set; } = new ArrayList();

            [Benchmark]
            public void Add()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Add(i);
                }
            }

            [Benchmark]
            public void Contains()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Contains(i);
                }
            }

            [Benchmark]
            public void Remove()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Remove(i);
                }
            }
        }
    }
}
