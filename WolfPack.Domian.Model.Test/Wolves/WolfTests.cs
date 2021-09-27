using System;
using FluentAssertions;
using WolfPack.Domian.Model.Shared.Exceptions;
using WolfPack.Domian.Model.Wolves;
using Xunit;

namespace WolfPack.Domian.Model.Test.Wolves
{
    public class WolfTests
    {
        private readonly IWolfFactory _iWolfFactory;

        public WolfTests()
        {
            _iWolfFactory = new WolfFactory();
        }

        #region [- Constructor -]
        
        [Fact]
        public void Constructor_Of_Wolf_Should_Generate_Id()
        {
            // arrange

            // act
            var sut = new WolfTestBuilder().Build();

            // assert
            sut.Id.Should().NotBe(Guid.Empty);
        }
        
        [Fact]
        public void Constructor_Of_Wolf_Should_Throw_DomainException_When_Code_Is_Null_Or_WhiteSpace()
        {
            // arrange
            var invalidCode = string.Empty;

            // act
            void Action()
            {
                new WolfFactory()
                    .WithNewWolfBuilder()
                    .WithCode(invalidCode)
                    .WithCreationDate(WolfTestBuilder.SomeCreationDate)
                    .WithModificationDate(WolfTestBuilder.SomeModificationDate)
                    .WithPersonalInformation(WolfTestBuilder.SomePersonalInformation)
                    .WithLocation(WolfTestBuilder.SomeLocation)
                    .Build();
                    
            }

            // assert
            var exception = Assert.Throws<DomainException>(Action);

            exception.ValidationMessage.Should().Be(WolfValidationMessage.CodeNullOrWhiteSpace);
        }
        
        [Fact]
        public void Constructor_Of_Wolf_Should_Throw_DomainException_When_Code_Is_Greater_Than_MaxLength()
        {
            // arrange
            var invalidCode = new string('a', Wolf.MaxCodeLength + 1);

            // act
            void Action()
            {
                new WolfFactory()
                    .WithNewWolfBuilder()
                    .WithCode(invalidCode)
                    .WithCreationDate(WolfTestBuilder.SomeCreationDate)
                    .WithModificationDate(WolfTestBuilder.SomeModificationDate)
                    .WithPersonalInformation(WolfTestBuilder.SomePersonalInformation)
                    .WithLocation(WolfTestBuilder.SomeLocation)
                    .Build();
            }

            // assert
            var exception = Assert.Throws<DomainException>(Action);

            exception.ValidationMessage.Should().Be(WolfValidationMessage.GreaterThanMaxCode);
        }
        #endregion
    }
}