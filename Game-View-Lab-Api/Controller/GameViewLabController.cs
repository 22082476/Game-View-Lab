using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]/lib")]
public class GameViewLabController : ControllerBase
{
    private readonly GameViewLabContext _context;
    private readonly IImageService _service;


    public GameViewLabController (GameViewLabContext context, IImageService service)
    {
        _context = context;
        _service = service;
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
    public async Task<IActionResult> PutLib ([FromBody] RequestModel requestModel)
    {
        if (requestModel != null)
        {
            if(await _context.Games.AnyAsync ((g) => g.Id == requestModel.Game.Id))
            {
                try
                {   
                    _context.Games.Update (_service.ConvertToGame (requestModel));

                    await _context.SaveChangesAsync ();
                
                    return Ok (requestModel);
                }
                catch (DbUpdateException e)
                {
                    return StatusCode (500, e);
                }
            }
            
            return NotFound (requestModel.Game);
        }

        return BadRequest ("Game is required");
    }

    [HttpPost]
    public async Task<IActionResult> PostLib ([FromBody] RequestModel requestModel)
    {
        if (requestModel != null)
        {

            if (!await _context.Games.AnyAsync ((g) => g.Name == requestModel.Game.Name))
            {
                var add = _context.Games.AddAsync (_service.ConvertToGame (requestModel));

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
