using Castle.Core.Logging;
using InnovaCatalog.Controllers;
using InnovaCatalog.DbContexts;
using InnovaCatalog.Models;
using InnovaCatalog.Models.Dto;
using InnovaCatalog.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InnovaCatalogNUnitTest.Test
{
    [TestFixture]
    public class UsuarioResponse200
    {
        [Test]
        public async Task UsuarioController_Get_Response200()

        {

            // Arrange
            var usuarioRepoMock = new Mock<IUsuarioRepositorio>();
            var modelo = new LoginRequestDTO();

            // Configura el comportamiento del repositorio mock
            usuarioRepoMock.Setup(repo => repo.Login(modelo)).ReturnsAsync(new LoginResponseDTO
            {
                Usuario = new Usuario { UserName="BenitoO"},
                Token = "Admin123"
            });

            var controller = new UsuarioController(usuarioRepoMock.Object);

            // Act
            var result = await controller.Login(modelo);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);


        }
    }
}
