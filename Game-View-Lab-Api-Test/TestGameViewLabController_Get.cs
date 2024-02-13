using Microsoft.AspNetCore.Mvc;

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
        var controller = new GameViewLabController (_fixture.Context);

        //Act
        var result = controller.GetLib ().GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<OkObjectResult> (result);
    }

    [Fact]
    public void Test_GetLib_Ok_Empty ()
    {
         //Arrang
        var controller = new GameViewLabController (_fixture.ContextWithout);

        //Act
        var result = controller.GetLib ().GetAwaiter ().GetResult ();

        //Assert
        Assert.IsType<OkObjectResult> (result);
    }
}