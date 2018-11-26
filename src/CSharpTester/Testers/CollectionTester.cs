using System.Collections.Generic;

namespace CSharpTester.Testers
{
    public class CollectionTester<T> : ITester where T : class
    {
        private T _object;

        public CollectionTester(T type)
        {
            _object = type;
        }

        public TestResult RunTests()
        {
            var collection = new List<T>();

            return new TestResult();
        }
    }
}