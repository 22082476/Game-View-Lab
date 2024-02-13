using Microsoft.AspNetCore.Mvc;

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
        var controller = new GameViewLabController (_fixture.Context);
        var dataObject = new Game { Id = 1, Name = "The Finals 2"};

        //Act
        var result = controller.PutLib (dataObject).GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<OkObjectResult> (result);
    }

    [Fact]
    public void Test_PutLib_NotFound()
    {
         //Arrang
        var controller = new GameViewLabController (_fixture.Context);
        var dataObject = new Game { Id = 4, Name = "Minecraft"};

        //Act
        var result = controller.PutLib (dataObject).GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<NotFoundObjectResult> (result);
    }

    [Fact]
    public void Test_PutLib_BadRequest()
    {
         //Arrang
        var controller = new GameViewLabController (_fixture.Context);
        Game dataObject = null!;

        //Act
        var result = controller.PutLib (dataObject).GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<BadRequestObjectResult> (result);
    }
}