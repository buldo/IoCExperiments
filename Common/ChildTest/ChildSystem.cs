namespace Common.ChildTest
{
    public class ChildSystem : IChildSystem
    {
        private readonly IParentSystem _system;
        private readonly ChildConfig _config;

        public string WhoAmi { get { return _config.Name; } }

        public ChildSystem(IParentSystem system, ChildConfig config)
        {
            _system = system;
            _config = config;
        }
    }
}
