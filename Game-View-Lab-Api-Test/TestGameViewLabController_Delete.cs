using Microsoft.AspNetCore.Mvc;
using Moq;

public class TestGameViewLabController_Delete : IClassFixture<GameFixture>
{
    private readonly GameViewLabFixture _fixture;

    public TestGameViewLabController_Delete (GameFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_DelLib_NoContent ()
    {
        //Arrang
        var imageServiceMock = new Mock<IImageService>();
        var controller = new GameViewLabController (_fixture.Context, imageServiceMock.Object);
        var dataObject = new Game {Id = 1, Name = "The Finals"};

        //Act
        var result = controller.DelLib (dataObject.Id).GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<NoContentResult> (result);
    }

     [Fact]
    public void Test_DelLib_NotFound ()
    {
        //Arrang
        var imageServiceMock = new Mock<IImageService>();
        var controller = new GameViewLabController (_fixture.Context, imageServiceMock.Object);
        var dataObject = new Game {Id = 1, Name = "The Finals"};

        //Act
        var result = controller.DelLib (dataObject.Id).GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<NotFoundObjectResult> (result);
    }
}