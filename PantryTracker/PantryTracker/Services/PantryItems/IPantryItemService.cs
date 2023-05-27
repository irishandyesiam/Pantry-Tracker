using ErrorOr;
using PantryTracker.Models;

namespace PantryTracker.Services.PantryItems;

public interface IPantryItemService
{
    void CreatePantryItem(PantryItem pantryItem);
    void DeleteItem(Guid id);
    ErrorOr<PantryItem> GetItem(Guid id);
    void UpsertItem(PantryItem item);
}