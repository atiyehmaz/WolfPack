namespace WolfPack.Domian.Model.Packs
{
    public interface IPackFactory
    {
        IPackBuilder WithNewPackBuilder();
    }
}