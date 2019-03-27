using BenchmarkDotNet.Attributes;

namespace CSharpTester.Tests
{
    [ClrJob(true), CoreJob, MonoJob]
    [RankColumn, JsonExporter("Baseline")]
    public class BaselineTests
    {
        [Params(1, 10, 1000, 10000)]
        public int Count { get; set; }

        [Benchmark]
        public int BaselineTest()
        {
            var i = 0;

            for (; i < Count; i++)
            {}

            return i;
        }
    }
}
