using Microsoft.AspNetCore.Mvc;
using Moq;

public class TestGameViewLabController_Get : IClassFixture<GameFixture>
{
    private readonly GameViewLabFixture _fixture;

    public TestGameViewLabController_Get (GameFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_GetLib_Ok ()
    {
        //Arrang
        var imageServiceMock = new Mock<IImageService>();
        var controller = new GameViewLabController (_fixture.Context, imageServiceMock.Object);

        //Act
        var result = controller.GetLib ().GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<OkObjectResult> (result);
    }

    [Fact]
    public void Test_GetLib_Ok_Empty ()
    {
         //Arrang
        var imageServiceMock = new Mock<IImageService>();
        var controller = new GameViewLabController (_fixture.Context, imageServiceMock.Object);

        //Act
        var result = controller.GetLib ().GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<OkObjectResult> (result);
    }
}