using System;
using FluentAssertions;
using WolfPack.Domian.Model.Packs;
using WolfPack.Domian.Model.Shared.Exceptions;
using Xunit;

namespace WolfPack.Domian.Model.Test.Packs
{
    public class PackTests
    {
        private readonly IPackFactory _iPackFactory;

        public PackTests()
        {
            _iPackFactory = new PackFactory();
        }
        
        #region [- Constructor -]
        [Fact]
        public void Constructor_Of_Pack_Should_Generate_Id()
        {
            // arrange

            // act
            var sut = new PackTestBuilder().Build();

            // assert
            sut.Id.Should().NotBe(Guid.Empty);
        }
        
        [Fact]
        public void Constructor_Of_Pack_Should_Throw_DomainException_When_Name_Is_Null_Or_WhiteSpace()
        {
            // arrange
            var invalidName = string.Empty;

            // act
            void Action()
            {
                new PackFactory()
                    .WithNewPackBuilder()
                    .WithName(invalidName)
                    .WithWolves(PackTestBuilder.SomeWolves)
                    .Build();
                    
            }

            // assert
            var exception = Assert.Throws<DomainException>(Action);

            exception.ValidationMessage.Should().Be(PackValidationMessage.NameNullOrWhiteSpace);
        }
        
        [Fact]
        public void Constructor_Of_Pack_Should_Throw_DomainException_When_Name_Is_Greater_Than_MaxLength()
        {
            // arrange
            var invalidName = new string('a', Pack.MaxNameLength + 1);

            // act
            void Action()
            {
                new PackFactory()
                    .WithNewPackBuilder()
                    .WithName(invalidName)
                    .WithCreationDate(PackTestBuilder.SomeCreationDate)
                    .WithModificationDate(PackTestBuilder.SomeModificationDate)
                    .WithWolves(PackTestBuilder.SomeWolves)
                    .Build();
            }

            // assert
            var exception = Assert.Throws<DomainException>(Action);

            exception.ValidationMessage.Should().Be(PackValidationMessage.GreaterThanMaxName);
        }
        #endregion
    }
}