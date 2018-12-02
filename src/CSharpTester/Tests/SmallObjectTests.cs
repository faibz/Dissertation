using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using CSharpTester.Objects;

namespace CSharpTester.Tests
{
    public class SmallObjectTests
    {
        [ClrJob(true), CoreJob, MonoJob, CoreRtJob]
        [RPlotExporter, RankColumn, JsonExporter("List-SmallObject")]
        public class ListTests : ITestCollection
        {
            public IList<SmallObject> Collection { get; set; } = new List<SmallObject>();
            private readonly SmallObject _object = new SmallObject(0, 'a');

            [Benchmark]
            public void Add()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Add(_object);
                }
            }

            [Benchmark]
            public void Contains()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Contains(_object);
                }
            }

            [Benchmark]
            public void Remove()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Remove(_object);
                }
            }
        }

        [ClrJob(true), CoreJob, MonoJob, CoreRtJob]
        [RPlotExporter, RankColumn, JsonExporter("Hashset-SmallObject")]
        public class HashsetTests : ITestCollection
        {
            public HashSet<SmallObject> Collection { get; set; } = new HashSet<SmallObject>();
            private readonly SmallObject _object = new SmallObject(0, 'a');

            [Benchmark]
            public void Add()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Add(_object);
                }
            }

            [Benchmark]
            public void Contains()
            {
                for (var i = 0; i < 100_000_000; i++)
                {
                    Collection.Add(_object);
                }
            }

            [Benchmark]
            public void Remove()
            {
                Collection.Remove(_object);
            }
        }
    }
}
