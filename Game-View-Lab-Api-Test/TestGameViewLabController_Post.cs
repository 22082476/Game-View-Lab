using Microsoft.AspNetCore.Mvc;

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
        var controller = new GameViewLabController (_fixture.Context);
        var dataObject = new Game {Name = "The Finals 2"};

        //Act
        var result = controller.PostLib (dataObject).GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<CreatedResult> (result);
    }

    [Fact]
    public void Test_PostLib_BadRequest_GameRequired()
    {
         //Arrang
        var controller = new GameViewLabController (_fixture.Context);
        Game dataObject = null!;

        //Act
        var result = controller.PostLib (dataObject).GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<BadRequestObjectResult> (result);
    }

    [Fact]
    public void Test_PostLib_BadRequest_GameAlreadyExistis()
    {
         //Arrang
        var controller = new GameViewLabController (_fixture.Context);
        var dataObject = new Game {Name = "The Finals"};

        //Act
        var result = controller.PostLib (dataObject).GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<BadRequestObjectResult> (result);
    }
}