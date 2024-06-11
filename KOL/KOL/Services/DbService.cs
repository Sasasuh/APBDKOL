using KOL.Data;
using KOL.Models;
using Microsoft.EntityFrameworkCore;

namespace KOL.Services;

using System.Collections.Generic;
using System.Threading.Tasks;



public class DbService : IDbService
{
    private readonly DatabaseContext _context;
 
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
 
    public async Task<Character?> GetCharacterByIdAsync(int characterId)
    {
        return await _context.Characters
            .Include(c => c.Backpacks)
            .ThenInclude(b => b.Item)
            .Include(c => c.CharacterTitles)
            .ThenInclude(ct => ct.Title)
            .FirstOrDefaultAsync(c => c.Id == characterId);
    }
 
    public async Task<bool> DoesItemExistAsync(int itemId)
    {
        return await _context.Items.AnyAsync(i => i.Id == itemId);
    }
 
    public async Task<bool> CanAddItemsToCharacterAsync(int characterId, List<int> itemIds)
    {
        var character = await _context.Characters.FindAsync(characterId);
        if (character == null) return false;
 
        var items = await _context.Items.Where(i => itemIds.Contains(i.Id)).ToListAsync();
        var totalWeight = items.Sum(i => i.Weight);
 
        return (character.CurrentWeight + totalWeight) <= character.MaxWeight;
    }
 
    public async Task AddItemsToCharacterAsync(int characterId, List<int> itemIds)
    {
        var character = await _context.Characters.FindAsync(characterId);
        var items = await _context.Items.Where(i => itemIds.Contains(i.Id)).ToListAsync();
 
        foreach (var item in items)
        {
            var backpack = await _context.Backpacks.FindAsync(characterId, item.Id);
            if (backpack == null)
            {
                backpack = new Backpack { CharacterId = characterId, ItemId = item.Id, Amount = 1 };
                _context.Backpacks.Add(backpack);
            }
            else
            {
                backpack.Amount += 1;
            }
 
            character.CurrentWeight += item.Weight;
        }
 
        await _context.SaveChangesAsync();
    }
}