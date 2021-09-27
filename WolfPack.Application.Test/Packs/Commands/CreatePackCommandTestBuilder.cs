using System;
using System.Collections.Generic;
using WolfPack.Application.Packs.Commands;

namespace WolfPack.Application.Test.Packs.Commands
{
    public class CreatePackCommandTestBuilder
    {
        private const string SomeName = "SomeName";
        public static ISet<Guid> SomeWolves =
            new HashSet<Guid>() { Guid.NewGuid() };

        private const string AnotherName = "AnotherName";
        public static ISet<Guid> AnotherWolves =
            new HashSet<Guid>() { Guid.NewGuid() };

        private readonly CreatePackCommand _built = new CreatePackCommand();

        public CreatePackCommand Build()
        {
            _built.Name = SomeName;
            _built.Wolves = SomeWolves;
            return _built;
        }

        public CreatePackCommand BuildWithAnother()
        {
            _built.Name = AnotherName;
            _built.Wolves = AnotherWolves;
            return _built;
        }
    }
}