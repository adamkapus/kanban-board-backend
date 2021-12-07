using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemalabBackend.BL;
using TemalabBackend.Controllers;
using TemalabBackend.DAL.EF;

namespace Tests
{
    [TestClass] // this class contains test code
    public class ControllerTest
    {
        [TestMethod] // this is a test instance
        public async Task GetToDoByID()
        {
            
            var mockManager = new Mock<IToDoManager>();
            mockManager.Setup(x => x.GetToDoOrNull(42)).ReturnsAsync(new ToDoItem { ID = 42 });

            var controller = new ToDoItemsController(mockManager.Object);

            
            var result = await controller.GetToDoItem(42);

          
            var item = result.Value;
            Assert.AreEqual(42, item.ID);
            
        }


        [TestMethod]
        public async Task TryingGettingNonExistingToDo()
        {

            var mockManager = new Mock<IToDoManager>();
            mockManager.Setup(x => x.GetToDoOrNull(It.IsAny<int>())).ReturnsAsync((ToDoItem)null);

            var controller = new ToDoItemsController(mockManager.Object);


            var result = await controller.GetToDoItem(120);

            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));

            Assert.IsNotNull(result);
        }



        [TestMethod]
        public async Task PutToDoWithInvalidID()
        {

            var mockManager = new Mock<IToDoManager>();
           

            var controller = new ToDoItemsController(mockManager.Object);


            var result = await controller.PutToDoItem(120, new ToDoItem { ID = 1 });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));

        }

        [TestMethod]
        public async Task PutToDoWithNonExistingID()
        {

            var mockManager = new Mock<IToDoManager>();
            mockManager.Setup(x => x.ModifyToDo(It.IsAny<ToDoItem>())).ReturnsAsync(false);

            var controller = new ToDoItemsController(mockManager.Object);


            var result = await controller.PutToDoItem(1, new ToDoItem { ID = 1 });
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

        }


        [TestMethod]
        public async Task DeleteToDoWithNotExistingID()
        {

            var mockManager = new Mock<IToDoManager>();
            mockManager.Setup(x => x.GetToDoOrNull(It.IsAny<int>())).ReturnsAsync((ToDoItem)null);

            var controller = new ToDoItemsController(mockManager.Object);


            var result = await controller.DeleteToDoItem(120);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public async Task DeleteToDoConflict()
        {

            var mockManager = new Mock<IToDoManager>();
            mockManager.Setup(x => x.GetToDoOrNull(It.IsAny<int>())).ReturnsAsync(new ToDoItem { ID = 1 });
            mockManager.Setup(x => x.DeleteToDo(It.IsAny<int>())).ReturnsAsync(false);
            var controller = new ToDoItemsController(mockManager.Object);

            var result = await controller.DeleteToDoItem(1);

            Assert.IsInstanceOfType(result, typeof(ConflictResult));

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public async Task DeleteToDo()
        {

            var mockManager = new Mock<IToDoManager>();
            mockManager.Setup(x => x.GetToDoOrNull(It.IsAny<int>())).ReturnsAsync(new ToDoItem { ID =1});
            mockManager.Setup(x => x.DeleteToDo(It.IsAny<int>())).ReturnsAsync(true);
            var controller = new ToDoItemsController(mockManager.Object);

            var result = await controller.DeleteToDoItem(1);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));

            Assert.IsNotNull(result);
        }
    }
}
