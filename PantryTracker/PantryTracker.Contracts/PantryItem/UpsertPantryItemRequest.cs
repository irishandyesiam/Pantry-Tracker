namespace PantryTracker.Contracts.PantryItem;

public record UpsertPantryItemRequest(
    string Name,
    double Quantity,
    string Unit,
    DateOnly ExpDate,
    string Location,
    DateTime StartDateTime,
    DateTime EndDateTime);