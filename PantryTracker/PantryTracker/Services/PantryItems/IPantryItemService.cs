using ErrorOr;
using PantryTracker.Models;

namespace PantryTracker.Services.PantryItems;

public interface IPantryItemService
{
    ErrorOr<Created> CreatePantryItem(PantryItem pantryItem);
    ErrorOr<Deleted> DeleteItem(Guid id);
    ErrorOr<PantryItem> GetItem(Guid id);
    ErrorOr<UpsertedPantryItem> UpsertItem(PantryItem item);
}