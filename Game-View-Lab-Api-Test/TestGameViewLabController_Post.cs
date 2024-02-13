using Microsoft.AspNetCore.Mvc;
using Moq;

public class TestGameViewLabController_Post : IClassFixture<GameFixture>
{
    private readonly GameViewLabFixture _fixture;

    public TestGameViewLabController_Post (GameFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_PostLib_Created ()
    {
        //Arrang
        var imageServiceMock = new Mock<IImageService>();
        imageServiceMock.Setup((m) => m.ConvertToGame(It.IsAny<RequestModel>())).Returns(() => new Game {Name = "The Finals 2"});
        var controller = new GameViewLabController (_fixture.Context, imageServiceMock.Object);
        var dataObject = new RequestModel {Game = new Game {Name = "The Finals 2"}, ImageBase64 = "string"};

        //Act
        var result = controller.PostLib (dataObject).GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<CreatedResult> (result);
    }

    [Fact]
    public void Test_PostLib_BadRequest_GameRequired()
    {
         //Arrang
        var imageServiceMock = new Mock<IImageService>();
        imageServiceMock.Setup((m) => m.ConvertToGame(It.IsAny<RequestModel>()));
        var controller = new GameViewLabController (_fixture.Context, imageServiceMock.Object);
        RequestModel dataObject = null!;

        //Act
        var result = controller.PostLib (dataObject).GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<BadRequestObjectResult> (result);
    }

    [Fact]
    public void Test_PostLib_BadRequest_GameAlreadyExistis()
    {
         //Arrang
        var imageServiceMock = new Mock<IImageService>();
        imageServiceMock.Setup((m) => m.ConvertToGame(It.IsAny<RequestModel>())).Returns(() => new Game {Name = "The Finals"});
        var controller = new GameViewLabController (_fixture.Context, imageServiceMock.Object);
        var dataObject = new RequestModel {Game = new Game {Name = "The Finals"}, ImageBase64 = "string"};

        //Act
        var result = controller.PostLib (dataObject).GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<BadRequestObjectResult> (result);
    }
}