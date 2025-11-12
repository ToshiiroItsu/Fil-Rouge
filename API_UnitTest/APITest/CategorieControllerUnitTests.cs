using API_Fil_Rouge.BusinessLogicLayer.Interfaces;
using API_Fil_Rouge.Controllers;
using API_Fil_Rouge.Models.BO;
using API_Fil_Rouge.Models.DTO.Entre;
using API_Fil_Rouge.Models.DTO.Sortie;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace API_UnitTest.APITest
{
    public class CategorieControllerUnitTests
    {
        private readonly Mock<ICookBookService> _mockCookbookService;
        private readonly Mock<IValidator<CreateCategorieDTO>> _mockValidator;
        private readonly CategoriesController _controller;

        public CategorieControllerUnitTests()
        {
            _mockCookbookService = new Mock<ICookBookService>();
            _mockValidator = new Mock<IValidator<CreateCategorieDTO>>();
            _controller = new CategoriesController(_mockCookbookService.Object);
        }

        [Fact]
        public async Task CreateCategorie_Should_Be_OkObjectResult_With_Empty_List()
        {
            // Arrange
            var request = new CreateCategorieDTO { nom = "Desserts" };

            // On configure le validateur pour ne pas lancer d'exception
            _mockValidator
                .Setup(v => v.Validate(It.IsAny<CreateCategorieDTO>()))
                .Returns(new ValidationResult());

            // On simule le service qui renvoie une catégorie vide (cas liste vide ou donnée minimale)
            _mockCookbookService
                .Setup(s => s.CreateCategorieAsync(It.IsAny<Categorie>()))
                .ReturnsAsync(new Categorie { id = 1, nom = "Desserts" });

            // Act
            var result = await _controller.CreateCategorie(_mockValidator.Object, request);

            // Assert
            result.Should().BeOfType<CreatedAtActionResult>();
            var createdResult = result as CreatedAtActionResult;
            createdResult?.Value.Should().BeOfType<API_Fil_Rouge.Models.DTO.Sortie.CategorieDTO>();

            var categorie = createdResult?.Value as API_Fil_Rouge.Models.DTO.Sortie.CategorieDTO;
            categorie?.id.Should().Be(1);
            categorie?.nom.Should();
        }
    }
}
