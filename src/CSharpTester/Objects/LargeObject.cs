namespace CSharpTester.Objects
{
    public class LargeObject
    {
        public SmallObject ObjectProperty { get; set; } = new SmallObject();
        public SmallObject ObjectProperty2 { get; set; } = new SmallObject();
        public SmallObject ObjectProperty3 { get; set; } = new SmallObject();
        public SmallObject ObjectProperty4 { get; set; } = new SmallObject();
        public SmallObject ObjectProperty5 { get; set; } = new SmallObject();
        public int IntProperty { get; set; } = 0;
    }
}