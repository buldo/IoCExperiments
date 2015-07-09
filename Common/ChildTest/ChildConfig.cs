namespace Common.ChildTest
{
    public class ChildConfig
    {
        public string Name { get; private set; }

        public ChildConfig(string name)
        {
            Name = name;
        }
    }
}
