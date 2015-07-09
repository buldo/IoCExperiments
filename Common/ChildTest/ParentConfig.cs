namespace Common.ChildTest
{
    public class ParentConfig
    {
        public string Name { get; private set; }

        public ParentConfig(string name)
        {
            Name = name;
        }
    }
}
