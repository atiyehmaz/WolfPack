using System;
using System.Collections.Generic;
using WolfPack.Domian.Model.Packs;
using WolfPack.Domian.Model.Test.Wolves;

namespace WolfPack.Domian.Model.Test.Packs
{
    public class PackTestBuilder
    {
        public static Guid SomeId = Guid.NewGuid();
        public const string SomeName = "SomeName";
        public static DateTime SomeCreationDate = new DateTime(DateTime.UtcNow.Ticks - 10);
        public static DateTime SomeModificationDate = new DateTime(DateTime.UtcNow.Ticks - 20);
        public static HashSet<Guid> SomeWolves = new HashSet<Guid>() { new WolfTestBuilder().Build().Id };
        
        public static Guid AnotherId = Guid.NewGuid();
        public const string AnotherName = "AnotherName";
        public static DateTime AnotherCreationDate = new DateTime(DateTime.UtcNow.Ticks - 30);
        public static DateTime AnotherModificationDate = new DateTime(DateTime.UtcNow.Ticks - 45);
        public static HashSet<Guid> AnotherWolves = new HashSet<Guid>() { new WolfTestBuilder().BuildWithAnother().Id };

        public Pack Build()
        {
            var pack= new PackFactory()
                .WithNewPackBuilder()
                .WithId(SomeId)
                .WithName(SomeName)
                .WithCreationDate(SomeCreationDate)
                .WithModificationDate(SomeModificationDate)
                .WithWolves(SomeWolves)
                .Build();
                
                return pack;
        }
        
        public Pack BuildWithAnother()
        {
            return new PackFactory()
                .WithNewPackBuilder()
                .WithId(AnotherId)
                .WithName(AnotherName)
                .WithCreationDate(AnotherCreationDate)
                .WithModificationDate(AnotherModificationDate)
                .WithWolves(AnotherWolves)
                .Build();
        }
    }
}