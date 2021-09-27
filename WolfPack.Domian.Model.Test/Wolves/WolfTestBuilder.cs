using System;
using WolfPack.Domian.Model.Wolves;
using WolfPack.Domian.Model.Wolves.Locations;
using WolfPack.Domian.Model.Wolves.PersonalInformations;

namespace WolfPack.Domian.Model.Test.Wolves
{
    public class WolfTestBuilder
    {
        public static Guid SomeId = Guid.NewGuid();
        public const string SomeCode = "SomeCode";
        public static DateTime SomeCreationDate = new DateTime(DateTime.UtcNow.Ticks - 10);
        public static DateTime SomeModificationDate = new DateTime(DateTime.UtcNow.Ticks - 20);
        
        public static readonly PersonalInformation SomePersonalInformation =
            new PersonalInformationTestBuilder().Build();
            
        public static readonly Location SomeLocation = new LocationTestBuilder().Build();
        
        
        public static Guid AnotherId = Guid.NewGuid();
        public const string AnotherCode = "AnotherCode";
        public static DateTime AnotherCreationDate = new DateTime(DateTime.UtcNow.Ticks - 30);
        public static DateTime AnotherModificationDate = new DateTime(DateTime.UtcNow.Ticks - 45);

        public static readonly PersonalInformation AnotherPersonalInformation =
            new PersonalInformationTestBuilder().BuildWithAnother();

        public static readonly Location AnotherLocation = new LocationTestBuilder().BuildWithAnother();

        public Wolf Build()
        {
            return new WolfFactory()
                .WithNewWolfBuilder()
                .WithId(SomeId)
                .WithCode(SomeCode)
                .WithCreationDate(SomeCreationDate)
                .WithModificationDate(SomeModificationDate)
                .WithPersonalInformation(SomePersonalInformation)
                .WithLocation(SomeLocation)
                .Build();
        }
        
        public Wolf BuildWithAnother()
        {
            return new WolfFactory()
                .WithNewWolfBuilder()
                .WithId(AnotherId)
                .WithCode(AnotherCode)
                .WithCreationDate(AnotherCreationDate)
                .WithModificationDate(AnotherModificationDate)
                .WithPersonalInformation(AnotherPersonalInformation)
                .WithLocation(AnotherLocation)
                .Build();
        }
    }
}