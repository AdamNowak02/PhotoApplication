using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PhotoApp.Controllers;
using PhotoApp.Models;
using Tests;  // Upewnij siê, ¿e namespace Tests zawiera referencjê do xUnit i inne potrzebne biblioteki
using Xunit;

namespace Tests
{
    public class PhotoControllerTests
    {
        [Fact]
        public void CreateReturnsViewResultWhenModelStateIsInvalid()
        {
            // Arrange
            var photoServiceMock = new Mock<IPhotoService>();
            var controller = new PhotoController(photoServiceMock.Object);
            controller.ModelState.AddModelError("PropertyName", "Error Message");

            // Act
            var result = controller.Create(new Photo());

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CreateCallsAddMethodWhenModelStateIsValid()
        {
            // Arrange
            var photoServiceMock = new Mock<IPhotoService>();
            var controller = new PhotoController(photoServiceMock.Object);
            var validPhoto = new Photo { /* uzupe³nij dane dla poprawnego obiektu Photo */ };

            // Act
            var result = controller.Create(validPhoto) as RedirectToActionResult;

            // Assert
            photoServiceMock.Verify(x => x.Add(validPhoto), Times.Once);
            Assert.Equal("Index", result?.ActionName);
        }


        [Fact]
        public void Create_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var photoServiceMock = new Mock<IPhotoService>();
            var controller = new PhotoController(photoServiceMock.Object);
            controller.ModelState.AddModelError("PropertyName", "Error Message");

            // Act
            var result = controller.Create(new Photo());

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_CallsAddMethod_WhenModelStateIsValid()
        {
            // Arrange
            var photoServiceMock = new Mock<IPhotoService>();
            var controller = new PhotoController(photoServiceMock.Object);
            var validPhoto = new Photo { /* uzupe³nij dane dla poprawnego obiektu Photo */ };

            // Act
            var result = controller.Create(validPhoto) as RedirectToActionResult;

            // Assert
            photoServiceMock.Verify(x => x.Add(validPhoto), Times.Once);
            Assert.Equal("Index", result?.ActionName);
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfPhotos()
        {
            // Arrange
            var photoServiceMock = new Mock<IPhotoService>();
            var controller = new PhotoController(photoServiceMock.Object);
            var photos = new List<Photo> { /* przyk³adowe obiekty Photo do zwrócenia */ };
            photoServiceMock.Setup(x => x.FindAll()).Returns(photos);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Photo>>(result.Model);
            Assert.Equal(photos.Count, model.Count());

          
        }
    }
}
