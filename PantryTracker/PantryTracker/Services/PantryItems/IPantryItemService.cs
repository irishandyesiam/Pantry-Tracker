using PantryTracker.Models;

namespace PantryTracker.Services.PantryItems;

public interface IPantryItemService
{
    void CreatePantryItem(PantryItem pantryItem);
    PantryItem GetItem(Guid id);
}