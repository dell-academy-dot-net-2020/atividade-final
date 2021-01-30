using Bogus;
using Dell.Academy.Atividade.Application.Models;
using Dell.Academy.Atividade.Application.Models.Validations;
using System.Linq;
using Xunit;

namespace Dell.Academy.Atividade.ApplicationTests
{
    [Collection(nameof(ApplicationTestsCollection))]
    public class EnderecoValidatorTests
    {
        private readonly Faker _faker;
        private readonly EnderecoValidator _validator;

        public EnderecoValidatorTests(ApplicationTestsFixture fixture)
        {
            _faker = fixture.Faker;
            _validator = new EnderecoValidator();
        }

        ///
        /////////////////////////////////////STREET//////////////////////////////////////////////////////////////////
        ///
        [Fact]
        public void ReceiveAValidAddress_ShouldValidateAddress()
        {
            // Arrange
            var address = new Endereco("Test Street", 1, "Test District", "60.000-000", "Test City", "TE", 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAnEmptyAddressStreet_ShouldValidateAddress()
        {
            // Arrange
            var address = new Endereco(string.Empty, 1, "Test District", "60.000-000", "Test City", "TE", 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Rua", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeAddressStreet_ShouldValidateAddress()
        {
            // Arrange
            var address = new Endereco("S1", 1, "Test District", "60.000-000", "Test City", "TE", 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Rua", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeAddressStreet_ShouldValidateAddress()
        {
            // Arrange
            var address = new Endereco(_faker.Random.AlphaNumeric(101), 1, "Test District", "60.000-000", "Test City", "TE", 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Rua", result.Errors.FirstOrDefault().PropertyName);
        }

        /////
        ///////////////////////////////////////NUMBER//////////////////////////////////////////////////////////////////
        /////

        [Fact]
        public void ReceiveASmallerAddressNumber_ShouldValidateAddress()
        {
            // Arrange
            var address = new Endereco("Test Street", _faker.Random.Number(-10, 0), "Test District", "60.000-000", "Test City", "TE", 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Numero", result.Errors.FirstOrDefault().PropertyName);
        }

        /////
        ///////////////////////////////////////CEP//////////////////////////////////////////////////////////////////
        /////

        [Fact]
        public void ReceiveAnEmptyAddressCep_ShouldValidateAddress()
        {
            // Arrange
            var address = new Endereco("Test Street", 1, "Test District", string.Empty, "Test City", "TE", 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cep", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeAddressCep_ShouldValidateAddress()
        {
            // Arrange;
            var address = new Endereco("Test Street", 1, _faker.Random.AlphaNumeric(9), "Test District", "Test City", "TE", 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cep", result.Errors.FirstOrDefault().PropertyName);
        }

        /////
        ///////////////////////////////////////DISTRICT//////////////////////////////////////////////////////////////////
        /////

        [Fact]
        public void ReceiveAnEmptyAddressDistrict_ShouldValidateAddress()
        {
            // Arrange
            var address = new Endereco("Test Street", 1, string.Empty, "60.000-000", "Test City", "TE", 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Bairro", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeAddressDistrict_ShouldValidateAddress()
        {
            // Arrange
            var address = new Endereco("Test Street", 1, "B1", "60.000-000", "Test City", "TE", 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Bairro", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeAddressDistrict_ShouldValidateAddress()
        {
            // Arrange
            var address = new Endereco("Test Street", 1, _faker.Random.AlphaNumeric(101), "60.000-000", "Test City", "TE", 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Bairro", result.Errors.FirstOrDefault().PropertyName);
        }

        /////
        ///////////////////////////////////////CITY//////////////////////////////////////////////////////////////////
        /////

        [Fact]
        public void ReceiveAnEmptyAddressCity_ShouldValidateAddress()
        {
            // Arrange
            var address = new Endereco("Test Street", 1, "Test District", "60.000-000", string.Empty, "TE", 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cidade", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeAddressCity_ShouldValidateAddress()
        {
            // Arrange
            var address = new Endereco("Test Street", 1, "Test District", "60.000-000", "C1", "TE", 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cidade", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeAddressCity_ShouldValidateAddress()
        {
            // Arrange
            var address = new Endereco("Test Street", 1, "Test District", "60.000-000", _faker.Random.AlphaNumeric(101), "TE", 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cidade", result.Errors.FirstOrDefault().PropertyName);
        }

        /////
        ///////////////////////////////////////STATE//////////////////////////////////////////////////////////////////
        /////

        [Fact]
        public void ReceiveAnEmptyAddressState_ShouldValidateAddress()
        {
            // Arrange
            var address = new Endereco("Test Street", 1, "Test District", "60.000-000", "Test City", string.Empty, 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Estado", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeAddressState_ShouldValidateAddress()
        {
            // Arrange
            var address = new Endereco("Test Street", 1, "Test District", "60.000-000", "Test City", "Test", 1);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Estado", result.Errors.FirstOrDefault().PropertyName);
        }
    }
}