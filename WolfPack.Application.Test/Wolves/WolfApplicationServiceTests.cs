using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using WolfPack.Application.Test.Wolves.Commands;
using WolfPack.Application.Wolves;
using WolfPack.Domian.Model.Test.Wolves;
using WolfPack.Domian.Model.Wolves;
using Xunit;

namespace WolfPack.Application.Test.Wolves
{
    public class WolfApplicationServiceTests
    {
        private readonly WolfRepositoryFake _wolfRepository;

        private readonly WolfApplicationService _sut;

        public WolfApplicationServiceTests()
        {
            _wolfRepository = new WolfRepositoryFake();
            _sut = BuildWolfApplicationService();
        }
        
        private WolfApplicationService BuildWolfApplicationService()
        {
            var wolfFactory = new WolfFactory();

            return new WolfApplicationService (wolfFactory, _wolfRepository);
        }
        
        [Fact]
        public void CreateWolf_Of_WolfApplicationService_Should_Add_Wolf()
        {
            // arrange

            var createWolfCommand = new CreateWolfCommandTestBuilder().Build();
              

            // act
            _sut.Create(createWolfCommand);

            // assert
            
            var actual = _wolfRepository.GetByCode(createWolfCommand.Code).Single();
            
            var expected=new WolfTestBuilder().Build();
            
            expected.SetId(actual.Id);
            expected.SetCode(createWolfCommand.Code);
            expected.SetCreationDate(actual.CreationDate);
            expected.SetModificationDate(actual.ModificationDate);
            expected.SetPersonalInformation(createWolfCommand.PersonalInformation);
            expected.SetLocation(createWolfCommand.Location);

            actual.Events=null;
            expected.Events=null;
           
            actual.Should().BeEquivalentTo(expected);

        }
        
        [Fact]
        public void Get_Of_WolfApplicationService_Should_Get_Wolf()
        {
            //arrange
            var someWolf = _sut.CreateSomeWolf();

            //act
            var actual = _sut.Get(someWolf.Id);

            //assert
            actual.Should().BeEquivalentTo(someWolf);
        }
        
        [Fact]
        public void GetByCode_Of_WolfApplicationService_Should_Get_Wolf()
        {
            //arrange

            var someWolf =  new CreateWolfCommandTestBuilder().Build();

            _sut.Create(someWolf);

            //act
            var actual = _sut.GetByCode(someWolf.Code);

            //assert

            var expected = _sut.Get(actual.Id);

            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void Remove_Of_WolfApplicationService_Should_Remove_Wolf()
        {
            //arrange
            var someWolf = _sut.CreateSomeWolf();

            //act
            _sut.Remove(someWolf.Id);

            //assert
            var actual = _sut.GetByCode(someWolf.Code);

            actual.Should().BeNull();
        }
        
        [Fact]
        public void GetAll_Of_WolfApplicationService_Should_Get_Wolves()
        {
            // arrange
            var someWolf = _sut.CreateSomeWolf();

            var anotherWolf = _sut.CreateAnotherWolf();

            // act

            var actual = _sut.GetAll();


            // assert

            var expected = new HashSet<Wolf>()
            {
                someWolf,
                anotherWolf
            };

            
            actual.Should().BeEquivalentTo(expected);

        }

    }
    
}