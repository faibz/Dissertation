using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.CsProj;

namespace CSharpTester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ////BASELINE TESTS
            //BenchmarkRunner.Run<Tests.BaselineTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));

            ////QUEUE TESTS
            //BenchmarkRunner.Run<Tests.PrimitiveTests.QueueTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            //BenchmarkRunner.Run<Tests.SmallObjectTests.QueueTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            //BenchmarkRunner.Run<Tests.LargeObjectTests.QueueTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));

            ////STACK TESTS
            //BenchmarkRunner.Run<Tests.PrimitiveTests.StackTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            //BenchmarkRunner.Run<Tests.SmallObjectTests.StackTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            //BenchmarkRunner.Run<Tests.LargeObjectTests.StackTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));

            ////SEQUENTIAL TESTS
            //BenchmarkRunner.Run<Tests.PrimitiveTests.LinkedListTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            //BenchmarkRunner.Run<Tests.SmallObjectTests.LinkedListTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            //BenchmarkRunner.Run<Tests.LargeObjectTests.LinkedListTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));

            //INDEX RETRIEVAL
            BenchmarkRunner.Run<Tests.PrimitiveTests.ListTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            //BenchmarkRunner.Run<Tests.SmallObjectTests.ListTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            //BenchmarkRunner.Run<Tests.LargeObjectTests.ListTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));

            //BenchmarkRunner.Run<Tests.PrimitiveTests.ArrayTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            //BenchmarkRunner.Run<Tests.SmallObjectTests.ArrayTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            //BenchmarkRunner.Run<Tests.LargeObjectTests.ArrayTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));

            ////KEY/VALUE PAIRS
            //BenchmarkRunner.Run<Tests.PrimitiveTests.DictionaryTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            //BenchmarkRunner.Run<Tests.SmallObjectTests.DictionaryTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            //BenchmarkRunner.Run<Tests.LargeObjectTests.DictionaryTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
        }
    }
}
