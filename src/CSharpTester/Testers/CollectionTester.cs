using System.Collections.Generic;
using CSharpTester.Objects;

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