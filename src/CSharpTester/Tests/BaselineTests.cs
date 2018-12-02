using BenchmarkDotNet.Attributes;

namespace CSharpTester.Tests
{
    [ClrJob(true), CoreJob, MonoJob, CoreRtJob]
    [RPlotExporter, RankColumn, JsonExporter("Baseline")]
    public class BaselineTests
    {
        [Benchmark]
        public void BaselineTest()
        {
            for (int i = 0; i < 100_000_000; i++)
            { }
        }
    }
}
