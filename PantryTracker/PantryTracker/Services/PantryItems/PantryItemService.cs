using PantryTracker.Models;

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

    public PantryItem GetItem(Guid id)
    {
        return _pantryItems[id];
    }

    public void UpsertItem(PantryItem pantryItem)
    {
        _pantryItems[pantryItem.Id] = pantryItem;
    }
}