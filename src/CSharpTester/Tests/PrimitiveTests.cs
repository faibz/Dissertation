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
    }
}
