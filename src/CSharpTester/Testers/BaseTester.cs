using CSharpTester.Objects;

namespace CSharpTester.Testers
{
    public class BaseTester : ITester
    {
        public TestResult RunTests()
        {
            return new TestResult();
        }
    }
}