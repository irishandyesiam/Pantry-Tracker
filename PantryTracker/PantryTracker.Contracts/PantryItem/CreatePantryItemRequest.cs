namespace PantryTracker.Contracts.PantryItem;

public record CreatePantryItemRequest(
    string Name,
    double Quantity,
    string Unit,
    DateOnly ExpDate,
    string Location,
    DateTime StartDateTime,
    DateTime EndDateTime)
{
    public DateTime LastModifiedDateTime;
}
