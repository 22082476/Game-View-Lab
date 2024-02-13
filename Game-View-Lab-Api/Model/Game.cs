using System.ComponentModel.DataAnnotations;

public class Game
{
    [Key] public int Id {get; set;}
    [Required] public string Name {get; set;}

    public byte[]? ImageData {get; set;}
}