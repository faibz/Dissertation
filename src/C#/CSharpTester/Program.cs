using BenchmarkDotNet.Running;

namespace CSharpTester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Tests.BaselineTests>();

            //QUEUE TESTS
            BenchmarkRunner.Run<Tests.PrimitiveTests.QueueTests>();
            BenchmarkRunner.Run<Tests.SmallObjectTests.QueueTests>();
            BenchmarkRunner.Run<Tests.LargeObjectTests.QueueTests>();

            //STACK TESTS
            BenchmarkRunner.Run<Tests.PrimitiveTests.StackTests>();
            BenchmarkRunner.Run<Tests.SmallObjectTests.StackTests>();
            BenchmarkRunner.Run<Tests.LargeObjectTests.StackTests>();

            //SEQUENTIAL TESTS
            BenchmarkRunner.Run<Tests.PrimitiveTests.LinkedListTests>();

            //Create bag tests?

            //INDEX RETRIEVAL
            BenchmarkRunner.Run<Tests.PrimitiveTests.ListTests>();
            BenchmarkRunner.Run<Tests.PrimitiveTests.ArrayTests>();
            BenchmarkRunner.Run<Tests.SmallObjectTests.ListTests>();
            BenchmarkRunner.Run<Tests.SmallObjectTests.ArrayTests>();
            BenchmarkRunner.Run<Tests.LargeObjectTests.ListTests>();
            BenchmarkRunner.Run<Tests.LargeObjectTests.ArrayTests>();

            //KEY/VALUE PAIRS
            BenchmarkRunner.Run<Tests.PrimitiveTests.DictionaryTests>();
            BenchmarkRunner.Run<Tests.SmallObjectTests.DictionaryTests>();
            BenchmarkRunner.Run<Tests.LargeObjectTests.DictionaryTests>();
        }
    }
}
