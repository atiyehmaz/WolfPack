using System.Linq;
using FluentAssertions;
using MongoDB.Driver;
using WolfPack.Domian.Model.Packs;
using WolfPack.Domian.Model.Test.Packs;
using WolfPack.Infrastructure.MongoDbRepository.Packs;
using Xunit;

namespace WolfPack.Infrastructure.MongoDbRepository.Test.Packs
{
    public class PackRepositoryTests
    {
        private readonly PackRepository _sut;

        public PackRepositoryTests()
        {
            var client = new MongoClient(new MongoDbConfiguration().GetConnectionString());
            _sut = new PackRepository(client, new PackFactory());

            CleanupRepository();
        }
        
        private void CleanupRepository()
        {
            CleanDuplicatedPacks(PackTestBuilder.SomeName);
        }
        
        private void CleanDuplicatedPacks(string name)
        {
            var packs = _sut.GetByName(name);
            
            foreach (var pack in packs)
            {
                _sut.Delete(pack);
        
            }
        }
        
        [Fact]
        public void Add_Of_PackRepository_Should_Add_Pack()
        {
            // arrange
            var expected = new PackTestBuilder().Build();
            expected.Events=null;
            
            // act
            _sut.Add(expected);
        
            // assert
            var actual = _sut.Get(expected.Id);
        
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void Get_Of_PackRepository_Should_Get_Pack()
        {
            // arrange
            var expected = new PackTestBuilder().Build();
            expected.Events = null;
        
            _sut.Add(expected);
        
            // act
            var actual = _sut.Get(expected.Id);
        
        
            // assert
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void GetByName_Of_PackRepository_Should_Get_Pack()
        {
            // arrange
            
            var expected = new PackTestBuilder().Build();
            expected.Events = null;
        
            _sut.Add(expected);
        
            // act
            var actual = _sut.GetByName(expected.Name).Single();
        
        
            // assert
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void Delete_Of_PackRepository_Should_Delete_Pack()
        {
            // arrange
            var expected = new PackTestBuilder().Build();
        
            _sut.Add(expected);
        
            // act
            _sut.Delete(expected);
        
            // assert
            
            var actual = _sut.Get(expected.Id);
        
            actual.Should().BeNull();
        }
        
        [Fact]
        public void GetAll_Of_PackRepository_Should_Get_Packs()
        {
            // arrange

            var allBefore = _sut.GetAll();

            var expected1 = new PackTestBuilder().Build();
            _sut.Add(expected1);

            var expected2 = new PackTestBuilder().BuildWithAnother();
            _sut.Add(expected2);

            // act

            var actual = _sut.GetAll();

            // assert
            expected1.Events = null;
            expected2.Events = null;

            actual.Should().BeEquivalentTo
            (
                allBefore.Union(new[] { expected1, expected2 })
            );
        }
        
        
        [Fact]
        public void Update_Of_PackRepository_Should_Update_Pack()
        {
            // arrange

            var expected = new PackTestBuilder()
                .Build();

            _sut.Add(expected);

             expected.Edit(PackTestBuilder.AnotherName, PackTestBuilder.AnotherWolves);

            // act

            _sut.Update(expected);


            // assert

            var actual = _sut.Get(expected.Id);

            actual.Should().BeEquivalentTo(expected);


        }
    }
}