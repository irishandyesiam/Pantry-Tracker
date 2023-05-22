using PantryTracker.Models;

namespace PantryTracker.Services.PantryItems;

public class PantryItemService : IPantryItemService
{
    private static readonly Dictionary<Guid, PantryItem> _pantryItems = new();
    public void CreatePantryItem(PantryItem pantryItem)
    {

    }

    public PantryItem GetItem(Guid id)
    {
        return _pantryItems[id];
    }
}