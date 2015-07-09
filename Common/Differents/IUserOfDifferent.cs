namespace Common.Differents
{
    public abstract class AbstractUserOfDifferent
    {
        public string WhoAmi { get { return Different != null ? Different.WhoAmi : "Undefined different"; } }
        public IDifferent Different { get; set; }
    }
}