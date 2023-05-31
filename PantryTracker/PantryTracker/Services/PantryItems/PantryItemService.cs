using ErrorOr;
using PantryTracker.Models;
using PantryTracker.ServiceErrors;

namespace PantryTracker.Services.PantryItems;

public class PantryItemService : IPantryItemService
{
    private static readonly Dictionary<Guid, PantryItem> _pantryItems = new();
    public ErrorOr<Created> CreatePantryItem(PantryItem pantryItem)
    {
        _pantryItems.Add(pantryItem.Id, pantryItem);

        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteItem(Guid id)
    {
        _pantryItems.Remove(id);

        return Result.Deleted;
    }

    public ErrorOr<PantryItem> GetItem(Guid id)
    {
        if (_pantryItems.TryGetValue(id, out var pantryItem))
        {
            return pantryItem;
        }

        return Errors.PantryItem.NotFound;
        
    }

    public ErrorOr<Updated> UpsertItem(PantryItem pantryItem)
    {
        _pantryItems[pantryItem.Id] = pantryItem;

        return Result.Updated;
    }
}