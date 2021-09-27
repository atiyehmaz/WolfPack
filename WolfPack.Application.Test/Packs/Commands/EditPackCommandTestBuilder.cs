using System;
using System.Collections.Generic;
using WolfPack.Application.Packs.Commands;

namespace WolfPack.Application.Test.Packs.Commands
{
    public class EditPackCommandTestBuilder
    {
        public static Guid SomeId = Guid.NewGuid();
        private const string SomeName = "SomeName";

        public static ISet<Guid> SomeWolves =
            new HashSet<Guid>() { Guid.NewGuid() };

        public static Guid AnotherId = Guid.NewGuid();
        private const string AnotherName = "AnotherName";

        public static ISet<Guid> AnotherWolves =
            new HashSet<Guid>() { Guid.NewGuid() };

        private readonly EditPackCommand _built = new EditPackCommand();

        public EditPackCommand Build()
        {
            _built.Id = SomeId;
            _built.Name = SomeName;
            _built.Wolves = SomeWolves;
            return _built;
        }

        public EditPackCommand BuildWithAnother()
        {
            _built.Id = AnotherId;
            _built.Name = AnotherName;
            _built.Wolves = AnotherWolves;
            return _built;
        }
        
        public EditPackCommand BuildWithId(Guid id)
        {
            _built.Id = id;
            _built.Name = AnotherName;
            _built.Wolves = AnotherWolves;
            return _built;
        }
    }
}