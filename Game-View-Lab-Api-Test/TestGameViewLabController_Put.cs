using Microsoft.AspNetCore.Mvc;
using Moq;

public class TestGameViewLabController_Put : IClassFixture<GameFixture>
{
    private readonly GameViewLabFixture _fixture;

    public TestGameViewLabController_Put (GameFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_PutLib_Ok ()
    {
        //Arrang
        var imageServiceMock = new Mock<IImageService>();
        imageServiceMock.Setup((m) => m.ConvertToGame(It.IsAny<RequestModel>())).Returns(() => new Game { Id = 1, Name = "The Finals 2"});
        var controller = new GameViewLabController (_fixture.Context, imageServiceMock.Object);
        var dataObject = new RequestModel {Game = new Game { Id = 1, Name = "The Finals 2"}, ImageBase64 = "string"};


        //Act
        var result = controller.PutLib (dataObject).GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<OkObjectResult> (result);
    }

    [Fact]
    public void Test_PutLib_NotFound()
    {
         //Arrang
        var imageServiceMock = new Mock<IImageService>();
        imageServiceMock.Setup((m) => m.ConvertToGame(It.IsAny<RequestModel>())).Returns(() => new Game { Id = 4, Name = "Minecraft"});
        var controller = new GameViewLabController (_fixture.Context, imageServiceMock.Object);
        var dataObject = new RequestModel {Game = new Game { Id = 4, Name = "Minecraft"}, ImageBase64 = "string"};
        //Act
        var result = controller.PutLib (dataObject).GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<NotFoundObjectResult> (result);
    }

    [Fact]
    public void Test_PutLib_BadRequest()
    {
         //Arrang
        var imageServiceMock = new Mock<IImageService>();
        imageServiceMock.Setup((m) => m.ConvertToGame(It.IsAny<RequestModel>()));
        var controller = new GameViewLabController (_fixture.Context, imageServiceMock.Object);
        RequestModel dataObject = null!;

        //Act
        var result = controller.PutLib (dataObject).GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<BadRequestObjectResult> (result);
    }
}