using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]/lib")]
public class GameViewLabController : ControllerBase
{
    private GameViewLabContext _context;

    public GameViewLabController (GameViewLabContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetLib ()
    {
        var lib = _context.Games.ToListAsync ();

        if (lib != null)
        {
            return Ok (await lib);
        }

        return NotFound ();
    }

    [HttpPut]
    public async Task<IActionResult> PutLib ([FromBody] Game game)
    {
        if (game != null)
        {
            if(await _context.Games.AnyAsync ((g) => g.Id == game.Id))
            {
                try
                {   
                    _context.Games.Update (game);

                    await _context.SaveChangesAsync ();
                
                    return Ok (game);
                }
                catch (DbUpdateException e)
                {
                    return StatusCode (500, e);
                }
            }
            
            return NotFound (game);
        }

        return BadRequest ("Game is required");
    }

    [HttpPost]
    public async Task<IActionResult> PostLib ([FromBody] Game game)
    {
        if (game != null)
        {

            if (!await _context.Games.AnyAsync ((g) => g.Name == game.Name))
            {
                var add = _context.Games.AddAsync (game);

                try 
                {
                    await add;
                    await _context.SaveChangesAsync ();

                    return Created ();

                }
                catch (DbUpdateException e)
                {
                    return StatusCode (500, e);
                }
            }

            return BadRequest ("Game already existis");

        }

        return BadRequest ("Game is required");
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DelLib (int id)
    {
        if (id != null)
        {

            var exsitingGame = await _context.Games.SingleOrDefaultAsync((g) => g.Id == id);

            if (exsitingGame != null)
            {
                try
                {
                    _context.Games.Remove(exsitingGame);

                    await _context.SaveChangesAsync ();
                
                    return NoContent ();
                }
                catch (DbUpdateException e)
                {
                    return StatusCode (500, e);
                }
            }

            return NotFound ("Game with Id " + id);

        }

        return BadRequest ("Game is required");
    }

}
