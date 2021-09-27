namespace WolfPack.Domian.Model.Wolves
{
    public class WolfFactory : IWolfFactory
    {
        public IWolfBuilder WithNewWolfBuilder()
        {
            return new WolfBuilder();
        }
    }
}