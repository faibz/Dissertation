using BenchmarkDotNet.Attributes;

namespace CSharpTester.Tests
{
    [ClrJob(true), CoreJob, MonoJob]
    [RPlotExporter, RankColumn, JsonExporter("Baseline")]
    public class BaselineTests
    {
        [Params(1, 10, 1000, 100_000_000)]
        public int Count { get; set; }

        [Benchmark]
        public void BaselineTest()
        {
            for (int i = 0; i < Count; i++)
            { }
        }
    }
}
