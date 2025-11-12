using API_Fil_Rouge.APITestIntegration.Fixture;
using API_Fil_Rouge.Models.DTO.Entre;
using API_Fil_Rouge.Models.DTO.Sortie;
using System.Net.Http;
using System.Net.Http.Json;

namespace API_Test_Integration
{
    public class CategorieControllerTest : IntegrationTest
    {
        public CategorieControllerTest(APIWebApplicationFactory webApi) : base(webApi)
        {
        }

        [Fact]
        public async void CreateCategorie_Should_Return_The_NewBook()
        {
            //Arrange
            UpDatabase();
            await Login("admin", "admin");
            CreateCategorieDTO createCategorieDTO = new CreateCategorieDTO()
            {
                nom = "Test",

            };

            CategorieDTO categorieDTO = new CategorieDTO()
            {
                id = 15,
                nom = "Test",

            };

            //Act
            var reponseHttp = await httpClient.PostAsJsonAsync($"/api/categories", createCategorieDTO);

            //Assert
            Assert.True(reponseHttp.IsSuccessStatusCode);
            var actual = await reponseHttp.Content.ReadFromJsonAsync<CategorieDTO>();

            Assert.Equivalent(categorieDTO, actual);
            //Clean Test
            Logout();

        }
    }
}