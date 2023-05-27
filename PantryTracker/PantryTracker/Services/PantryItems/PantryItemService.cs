using ErrorOr;
using PantryTracker.Models;
using PantryTracker.ServiceErrors;

namespace PantryTracker.Services.PantryItems;

public class PantryItemService : IPantryItemService
{
    private static readonly Dictionary<Guid, PantryItem> _pantryItems = new();
    public void CreatePantryItem(PantryItem pantryItem)
    {
        _pantryItems.Add(pantryItem.Id, pantryItem);
    }

    public void DeleteItem(Guid id)
    {
        _pantryItems.Remove(id);
    }

    public ErrorOr<PantryItem> GetItem(Guid id)
    {
        if (_pantryItems.TryGetValue(id, out var pantryItem))
        {
            return pantryItem;
        }

        return Errors.PantryItem.NotFound;
        
    }

    public void UpsertItem(PantryItem pantryItem)
    {
        _pantryItems[pantryItem.Id] = pantryItem;
    }
}