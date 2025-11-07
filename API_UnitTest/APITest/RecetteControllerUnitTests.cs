using API_Fil_Rouge.BusinessLogicLayer.Interfaces;
using API_Fil_Rouge.Controllers;
using API_Fil_Rouge.Models.BO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_UnitTest.APITest
{
    public class RecetteControllerUnitTests
    {
        [Fact]
        public async Task GetRecettes_Should_Be_OkObjectResult_Whit_Empty_List()
        {
            //Arrange 
            ICookBookService cookBookService = Mock.Of<ICookBookService>();
            Mock.Get(cookBookService)
                .Setup(b => b.GetAllRecettesAsync())
                .ReturnsAsync(new List<Recette>());

            RecettesController recettesController = new RecettesController(cookBookService);


            OkObjectResult expectedResult = new OkObjectResult(new List<Recette>());
            //Act
            var result = await recettesController.GetRecette();


            //Assert
            Assert.IsType(expectedResult.GetType(), result);

        }

    }
}
