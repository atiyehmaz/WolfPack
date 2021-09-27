using System.Linq;
using FluentAssertions;
using MongoDB.Driver;
using WolfPack.Domian.Model.Test.Wolves;
using WolfPack.Domian.Model.Wolves;
using WolfPack.Infrastructure.MongoDbRepository.Wolves;
using Xunit;

namespace WolfPack.Infrastructure.MongoDbRepository.Test.Wolves
{
    public class WolfRepositoryTests
    {
        private readonly WolfRepository _sut;

        public WolfRepositoryTests()
        {
            var client = new MongoClient(new MongoDbConfiguration().GetConnectionString());
            _sut = new WolfRepository(client, new WolfFactory());

            CleanupRepository();
            
        }
        
        
        private void CleanupRepository()
        {
            CleanDuplicatedWolves(WolfTestBuilder.SomeCode);
        }

        private void CleanDuplicatedWolves(string code)
        {
            var wolves = _sut.GetByCode(code);
            
            foreach (var wolf in wolves)
            {
                _sut.Delete(wolf);
        
            }
        }
        
        [Fact]
        public void Add_Of_WolfRepository_Should_Add_Wolf()
        {
            // arrange
            var expected = new WolfTestBuilder().Build();
            expected.Events=null;
            
            // act
            _sut.Add(expected);
        
            // assert
            var actual = _sut.Get(expected.Id);
        
            actual.Should().BeEquivalentTo(expected);
        }
        
        
        [Fact]
        public void Get_Of_WolfRepository_Should_Get_Wolf()
        {
            // arrange
            var expected = new WolfTestBuilder().Build();
            expected.Events = null;
        
            _sut.Add(expected);
        
            // act
            var actual = _sut.Get(expected.Id);
        
        
            // assert
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void GetByCode_Of_WolfRepository_Should_Get_Wolf()
        {
            // arrange
            
            var expected = new WolfTestBuilder().Build();
            expected.Events = null;
        
            _sut.Add(expected);
        
            // act
            var actual = _sut.GetByCode(expected.Code).Single();
        
        
            // assert
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void GetAll_Of_WolfRepository_Should_Get_Wolves()
        {
            // arrange

            var allBefore = _sut.GetAll();

            var expected1 = new WolfTestBuilder().Build();
            _sut.Add(expected1);

            var expected2 = new WolfTestBuilder().BuildWithAnother();
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
        public void Delete_Of_WolfRepository_Should_Delete_Wolf()
        {
            // arrange
            var expected = new WolfTestBuilder().Build();
        
            _sut.Add(expected);
        
            // act
            _sut.Delete(expected);
        
            // assert
            
            var actual = _sut.Get(expected.Id);
        
            actual.Should().BeNull();
        }
        
        [Fact]
        public void Update_Of_WolfRepository_Should_Update_Wolf()
        {
            // arrange

            var expected = new WolfTestBuilder()
                .Build();

            _sut.Add(expected);

            expected.Edit(WolfTestBuilder.AnotherCode, WolfTestBuilder.AnotherPersonalInformation,
                WolfTestBuilder.AnotherLocation);

            // act

            _sut.Update(expected);


            // assert

            var actual = _sut.Get(expected.Id);
            expected.Events=null;
            
            actual.Should().BeEquivalentTo(expected);


        }
    }
}