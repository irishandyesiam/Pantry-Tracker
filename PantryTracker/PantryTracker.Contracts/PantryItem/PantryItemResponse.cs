namespace PantryTracker.Contracts.PantryItem;

public record PantryItemResponse(
    Guid Id,
    string Name,
    double Quantity,
    string Unit,
    DateOnly ExpDate,
    string Location,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime);