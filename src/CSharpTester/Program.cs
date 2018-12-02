using BenchmarkDotNet.Running;

namespace CSharpTester
{
    public class Program
    {
        public static void Main(string[] args)
        {
//            var baselineTester = new BaseTester();
//            var baselineTestResults = baselineTester.RunTests();
//
//            var smallObjectTester = new CollectionTester<SmallObject>(new SmallObject());
//            var smallObjectTestResults = smallObjectTester.RunTests();
//
//            var largeObjectTester = new CollectionTester<LargeObject>(new LargeObject());
//            var largeObjectTestResults = largeObjectTester.RunTests();

            BenchmarkRunner.Run<Tests.BaselineTests>();

            BenchmarkRunner.Run<Tests.PrimitiveTests.ListTests>();
            BenchmarkRunner.Run<Tests.PrimitiveTests.HashsetTests>();

            BenchmarkRunner.Run<Tests.SmallObjectTests.ListTests>();
            BenchmarkRunner.Run<Tests.SmallObjectTests.HashsetTests>();
        }
    }
}
