namespace WolfPack.Domian.Model.Wolves
{
    public interface IWolfFactory
    {
        IWolfBuilder WithNewWolfBuilder();
    }
}