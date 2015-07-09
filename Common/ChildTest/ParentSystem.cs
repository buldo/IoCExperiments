namespace Common.ChildTest
{
    public class ParentSystem : IParentSystem
    {
        private readonly ParentConfig _config;

        public ChildConfig ChildConfig { get; private set; }
        public IChildSystem ChildSystem { get; set; }
        public string WhoAmi { get { return _config.Name; } }

        public ParentSystem(ParentConfig config)
        {
            _config = config;
            ChildConfig = new ChildConfig(_config.Name + ".Child");
        }
    }
}
