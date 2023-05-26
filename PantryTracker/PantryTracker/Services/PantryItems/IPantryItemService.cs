using PantryTracker.Models;

namespace PantryTracker.Services.PantryItems;

public interface IPantryItemService
{
    void CreatePantryItem(PantryItem pantryItem);
    void DeleteItem(Guid id);
    PantryItem GetItem(Guid id);
    void UpsertItem(PantryItem item);
}