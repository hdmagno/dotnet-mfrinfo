// using System;
// using System.Threading.Tasks;
// using Api.Application.Controllers;
// using Api.Domain.Dto;
// using Api.Domain.Interfaces.Services;
// using Microsoft.AspNetCore.Mvc;
// using Moq;
// using Xunit;

// namespace Api.Aplication.Test.Usuario.QuandoRequisitarCreate
// {
//     public class Retorno_Created
//     {
//         private UsersController _controller;

//         [Fact(DisplayName = "É possível realizar o created.")]
//         public async Task E_Possivel_Invocar_A_Controller_Create()
//         {
//             var serviceMock = new Mock<IUserService>();
//             var nome = Faker.Name.FullName();
//             var email = Faker.Internet.Email();

//             serviceMock.Setup(m => m.Post(It.IsAny<CreateUserDto>())).ReturnsAsync(
//                 new CreateUserDtoResult
//                 {
//                     Id = Guid.NewGuid(),
//                     Name = nome,
//                     Email = email,
//                     CreateAt = DateTime.UtcNow
//                 }
//             );

//             _controller = new UsersController(serviceMock.Object);

//             Mock<IUrlHelper> url = new Mock<IUrlHelper>();
//             url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
//             _controller.Url = url.Object;

//             var userDtoCreate = new CreateUserDto
//             {
//                 Name = nome,
//                 Email = email,
//             };

//             var result = await _controller.Post(userDtoCreate);
//             Assert.True(result is CreatedResult);

//             var resultValue = ((CreatedResult)result).Value as CreateUserDtoResult;
//             Assert.NotNull(resultValue);
//             Assert.Equal(userDtoCreate.Name, resultValue.Name);
//             Assert.Equal(userDtoCreate.Email, resultValue.Email);
//         }
//     }
// }
