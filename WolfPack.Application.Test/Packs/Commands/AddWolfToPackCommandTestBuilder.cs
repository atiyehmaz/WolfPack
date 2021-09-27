using System;
using WolfPack.Application.Packs.Commands;

namespace WolfPack.Application.Test.Packs.Commands
{
    public class AddWolfToPackCommandTestBuilder
    {
        public static Guid SomeId = Guid.NewGuid();
        public static Guid SomeWolf = Guid.NewGuid();


        private readonly AddWolfToPackCommand _built = new AddWolfToPackCommand();

        public AddWolfToPackCommand Build()
        {
            _built.Id = SomeId;
            _built.Wolf = SomeWolf;
            return _built;
        }

        public AddWolfToPackCommand BuildWithAnother(Guid anotherId, Guid anotherwolf)
        {
            _built.Id = anotherId;
            _built.Wolf = anotherwolf;
            return _built;
        }
    }
}