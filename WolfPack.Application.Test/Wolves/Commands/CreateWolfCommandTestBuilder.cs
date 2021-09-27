using System;
using WolfPack.Application.Wolves.Commands;
using WolfPack.Domian.Model.Test.Wolves;
using WolfPack.Domian.Model.Wolves.Locations;
using WolfPack.Domian.Model.Wolves.PersonalInformations;

namespace WolfPack.Application.Test.Wolves.Commands
{
    public class CreateWolfCommandTestBuilder
    {
        private const string SomeCode = "SomeCode";

        private static readonly PersonalInformation SomePersonalInformation =
            new PersonalInformationTestBuilder().Build();

        private static readonly Location SomeLocation = new LocationTestBuilder().Build();
        
        
        private const string AnotherCode = "AnotherCode";

        private static readonly PersonalInformation AnotherPersonalInformation =
            new PersonalInformationTestBuilder().BuildWithAnother();

        private static readonly Location AnotherLocation = new LocationTestBuilder().BuildWithAnother();
        
        private readonly CreateWolfCommand _built = new CreateWolfCommand();

        public CreateWolfCommand Build()
        {
            _built.Code= SomeCode;
            _built.PersonalInformation= SomePersonalInformation;
            _built.Location=SomeLocation;
            return _built;
        }
        
        public CreateWolfCommand BuildWithAnother()
        {
            _built.Code= AnotherCode;
            _built.PersonalInformation= AnotherPersonalInformation;
            _built.Location=AnotherLocation;
            return _built;
        }
        
    }
}