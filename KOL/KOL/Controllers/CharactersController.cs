using KOL.Models;
using KOL.Services;
using Microsoft.AspNetCore.Mvc;

namespace KOL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;

    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{characterId}")]
    public async Task<IActionResult> GetCharacterById(int characterId)
    {
        var character = await _dbService.GetCharacterByIdAsync(characterId);
        if (character == null)
        {
            return NotFound();
        }

        return Ok(new
        {
            character.FirstName,
            character.LastName,
            character.CurrentWeight,
            character.MaxWeight,
            BackpackItems = character.Backpacks.Select(b => new
            {
                b.Item.Name,
                b.Item.Weight,
                b.Amount
            }),
            Title = character.CharacterTitles.Select(ct => new
            {
                ct.Title.Name,
                ct.AcquiredAt
            })
        });
    }
    
    //Zabraklo troche czasu zeby to sensownie dopisac, ale idea byla taka ^^^
    //Oraz zabraklo czasu dopisac końcówke POST, ale przygotowałem wszystkie niezbędne metody dla tego w Services/DbService.cs
}