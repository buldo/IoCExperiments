namespace Common.Differents
{
    using System.Linq;

    public class UserOfUserOfDifferentCollection : IUserOfDifferentCollection
    {
        private readonly AbstractUserOfDifferent[] _users;

        public AbstractUserOfDifferent[] Users { get { return _users; } }

        public UserOfUserOfDifferentCollection(params AbstractUserOfDifferent[] users)
        {
            _users = users.ToArray();
        }
    }
}
