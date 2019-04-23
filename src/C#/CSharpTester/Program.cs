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
            //QUEUE TESTS
            BenchmarkRunner.Run<Tests.PrimitiveTests.QueueTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            BenchmarkRunner.Run<Tests.ObjectTests.QueueTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));

            //STACK TESTS
            BenchmarkRunner.Run<Tests.PrimitiveTests.StackTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            BenchmarkRunner.Run<Tests.ObjectTests.StackTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));

            //SEQUENTIAL TESTS
            BenchmarkRunner.Run<Tests.PrimitiveTests.LinkedListTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            BenchmarkRunner.Run<Tests.ObjectTests.LinkedListTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));

            //INDEX RETRIEVAL
            BenchmarkRunner.Run<Tests.PrimitiveTests.ListTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            BenchmarkRunner.Run<Tests.ObjectTests.ListTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));

            //KEY/VALUE PAIRS
            BenchmarkRunner.Run<Tests.PrimitiveTests.DictionaryTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
            BenchmarkRunner.Run<Tests.ObjectTests.DictionaryTests>(DefaultConfig.Instance.With(Job.Default.With(CsProjCoreToolchain.NetCoreApp22)));
        }
    }
}
