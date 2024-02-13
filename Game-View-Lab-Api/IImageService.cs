public interface IImageService
{
    Game ConvertToGame (RequestModel requestModel);
}

public class ImageService : IImageService
{
    public Game ConvertToGame(RequestModel requestModel)
    {
        try
        {
            byte[] imageData = Convert.FromBase64String(requestModel.ImageBase64);
        
            if (requestModel.Game.Id == null)
            {
                return new Game { Name = requestModel.Game.Name, ImageData = imageData };
            }
        
            return new Game { Id = requestModel.Game.Id, Name = requestModel.Game.Name, ImageData = imageData };
        }
        catch (FormatException ex)
        {
            // Log de foutmelding of voer andere foutafhandeling uit
            Console.WriteLine("Fout bij het decoderen van Base64-string: " + ex.Message);
            // Of gooi een aangepaste uitzondering om de fout verder te hanteren
            throw new Exception("Fout bij het decoderen van Base64-string", ex);
        }
}

}