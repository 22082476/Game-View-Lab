using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Name), IsUnique = true)]
public class Game
{
    public int Id {get; set;}
    [Required] public string Name {get; set;}
}