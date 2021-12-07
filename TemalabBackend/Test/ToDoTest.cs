/*using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using TemalabBackend.DAL.EF;
using TemalabBackend.DAL;
using TemalabBackend.BL;
using TemalabBackend.Controllers;
using Microsoft.AspNetCore.Mvc;*/

/*namespace TemalabBackend.Test
{
    [TestClass] // this class contains test code
    public class CustomerTest
    {
        [TestMethod] // this is a test instance
        public async Task ToDoTest()
        {
            // Unit test: Arrange, Act, Assert
            
            // repository is mocked with a replacement object for this test as this test verifies the business logic and not the database/repository
            var customerRepositoryMock = new Mock<IToDoItemRepository>();
            // mock setup: calling GetCustomer always returns null
            customerRepositoryMock.Setup(repo => repo.GetCustomerOrNull(It.IsAny<int>())).ReturnsAsync((Customer)null);


            // instantiate the business layer class with the mocks
            var vm = new CustomerManager(customerRepositoryMock.Object, orderRepositoryMock.Object);

            // calling delete must return false
            Assert.IsFalse(await vm.TryDeleteCustomer(123));

            // Arrange
            var mockRepository = new Mock<ToDoManager>();
            mockRepository.Setup(x => x.GetToDoOrNull(42))
                .ReturnsAsync(new ToDoItem { ID = 42 });

            var controller = new ToDoItemsController(mockRepository.Object);
            
            // Act
            Microsoft.AspNetCore.Mvc.ActionResult<ToDoItem> actionResult = await controller.GetToDoItem(42);
            var result = actionResult.Result;

            // Assert
            Assert.IsNotNull(actionResult);
            //Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(42, actionResult.Content.ID);
            var result = await controller.GetToDoItem(42);

            //Assert.IsInstanceOfType(ToDoItem, result);//Assert.IsInstanceOfType<ActionResult<ToDoItem>>(result);
            //var returnValue = Assert.IsType<List<IdeaDTO>>(actionResult.Value);
            var item = result.Value;
            Assert.AreEqual(42, item.ID);
        }
    }
}*/