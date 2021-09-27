using System;
using WolfPack.Domian.Model.Wolves;
using WolfPack.Domian.Model.Wolves.PersonalInformations;

namespace WolfPack.Domian.Model.Test.Wolves
{
    public class PersonalInformationTestBuilder
    {
        public const string SomeName = "SomeName";
        public static GenderType SomeGenderType = GenderType.Female;
        public static DateTime SomeBirthDate = new DateTime(DateTime.UtcNow.Ticks - 8);

        public const string AnotherName = "AnotherName";
        public static GenderType AnotherGenderType = GenderType.Male;
        public static DateTime AnotherBirthDate = new DateTime(DateTime.UtcNow.Ticks - 10);
        
        public PersonalInformation Build()
        {
            return new PersonalInformation(SomeName, SomeGenderType, SomeBirthDate);
        }
        
        public PersonalInformation BuildWithAnother()
        {
            return new PersonalInformation(AnotherName, AnotherGenderType, AnotherBirthDate);
        }
    }
}