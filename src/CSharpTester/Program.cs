using CSharpTester.Objects;
using CSharpTester.Testers;

namespace CSharpTester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var baselineTester = new BaseTester();
            var baselineTestResults = baselineTester.RunTests();

            var smallObjectTester = new CollectionTester<SmallObject>(new SmallObject());
            var smallObjectTestResults = smallObjectTester.RunTests();

            var largeObjectTester = new CollectionTester<LargeObject>(new LargeObject());
            var largeObjectTestResults = largeObjectTester.RunTests();

        }
    }
}
