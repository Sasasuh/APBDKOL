using KOL.Models;

namespace KOL.Services;

public interface IDbService
{
    Task<Character> GetCharacterByIdAsync(int characterId);
    Task<bool> DoesItemExistAsync(int itemId);
    Task<bool> CanAddItemsToCharacterAsync(int characterId, List<int> itemIds);
    Task AddItemsToCharacterAsync(int characterId, List<int> itemIds);
}