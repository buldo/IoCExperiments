namespace Common.Config
{
    public class Config
    {
        public string Name { get; private set; }

        public Config(string name)
        {
            Name = name;
        }
    }
}
