using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using WolfPack.Application.Packs;
using WolfPack.Application.Test.Packs.Commands;
using WolfPack.Domian.Model.Packs;
using WolfPack.Domian.Model.Test.Packs;
using Xunit;

namespace WolfPack.Application.Test.Packs
{
    public class PackApplicationServiceTests
    {
        private readonly PackRepositoryFake _packRepository;

        private readonly PackApplicationService _sut;

        public PackApplicationServiceTests()
        {
            _packRepository = new PackRepositoryFake();
            _sut = BuildPackApplicationService();
        }
        
        private PackApplicationService BuildPackApplicationService()
        {
            var packFactory = new PackFactory();

            return new PackApplicationService (packFactory, _packRepository);
        }
        
        [Fact]
        public void CreatePack_Of_PackApplicationService_Should_Add_Pack()
        {
            // arrange

            var createPackCommand = new CreatePackCommandTestBuilder().Build();
              

            // act
            _sut.Create(createPackCommand);

            // assert
            
            var actual = _packRepository.GetByName(createPackCommand.Name).Single();
            
            var expected=new PackTestBuilder().Build();
            
            expected.SetId(actual.Id);
            expected.SetName(createPackCommand.Name);
            expected.SetCreationDate(actual.CreationDate);
            expected.SetModificationDate(actual.ModificationDate);
            expected.SetWolves(createPackCommand.Wolves);
            actual.Events=null;
            expected.Events=null;
           
            actual.Should().BeEquivalentTo(expected);

        }
        
        [Fact]
        public void Edit_Of_PersonageGroupApplicationService_Should_Change_PersonageGroup()
        {
            // arrange

            var createPackCommand = new CreatePackCommandTestBuilder()
                .Build();

            _sut.Create(createPackCommand);

            var expected = _sut.GetByName(createPackCommand.Name);

            var editPersonageGroupCommand = new EditPackCommandTestBuilder().BuildWithId(expected.Id);

            expected.SetName(editPersonageGroupCommand.Name);
            expected.SetWolves(editPersonageGroupCommand.Wolves);

            // act

            _sut.Edit(editPersonageGroupCommand);
            
            // assert

            var actual = _sut.Get(expected.Id);

            actual
                .Should().BeEquivalentTo(
                    expected
                );

        }
        
        [Fact]
        public void Get_Of_PackApplicationService_Should_Get_Pack()
        {
            //arrange
            var somePack = _sut.CreateSomePack();

            //act
            var actual = _sut.Get(somePack.Id);

            //assert
            actual.Should().BeEquivalentTo(somePack);
        }
        
        [Fact]
        public void GetByName_Of_PackApplicationService_Should_Get_Pack()
        {
            //arrange

            var somePack =  new CreatePackCommandTestBuilder().Build();

            _sut.Create(somePack);

            //act
            var actual = _sut.GetByName(somePack.Name);

            //assert

            var expected = _sut.Get(actual.Id);

            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void Remove_Of_PackApplicationService_Should_Remove_Pack()
        {
            //arrange
            var somePack = _sut.CreateSomePack();

            //act
            _sut.Remove(somePack.Id);

            //assert
            var actual = _sut.GetByName(somePack.Name);

            actual.Should().BeNull();
        }
        
        [Fact]
        public void GetAll_Of_PackApplicationService_Should_Get_Pack()
        {
            // arrange
            var somePack = _sut.CreateSomePack();

            var anotherPack = _sut.CreateAnotherPack();

            // act

            var actual = _sut.GetAll();


            // assert

            var expected = new HashSet<Pack>()
            {
                somePack,
                anotherPack
            };

            
            actual.Should().BeEquivalentTo(expected);

        }
        
        [Fact]
        public void AddWolf_Of_PackApplicationService_Should_Add_Wolf_To_Pack()
        {
            // arrange

            var createPackCommand = new CreatePackCommandTestBuilder()
                .Build();

            _sut.Create(createPackCommand);

            var expected = _sut.GetByName(createPackCommand.Name);

            var anotherWolf = Guid.NewGuid();

            var addWolfToPackCommand = new AddWolfToPackCommandTestBuilder().BuildWithAnother(expected.Id, anotherWolf);

            // act

            _sut.AddWolfToPack(addWolfToPackCommand);


            // assert

            var actual = _sut.Get(expected.Id);

            actual.Should().BeEquivalentTo(expected);

        }
    }
}