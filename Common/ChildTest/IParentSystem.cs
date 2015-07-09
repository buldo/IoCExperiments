namespace Common.ChildTest
{
    public interface IParentSystem
    {
        IChildSystem ChildSystem { get; set; }
        string WhoAmi { get; }
    }
}
