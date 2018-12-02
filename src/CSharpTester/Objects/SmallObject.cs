namespace CSharpTester.Objects
{
    public class SmallObject
    {
        public SmallObject(int intProp, char charProp)
        {
            IntProperty = intProp;
            CharProperty = charProp;
        }

        public int IntProperty { get; set; }
        public char CharProperty { get; set; }
    }
}