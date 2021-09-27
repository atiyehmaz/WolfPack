namespace WolfPack.Domian.Model.Packs
{
    public class PackFactory : IPackFactory
    {
        public IPackBuilder WithNewPackBuilder()
        {
            return new PackBuilder();
        }
    }
}