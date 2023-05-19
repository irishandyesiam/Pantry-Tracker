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
    DateTime LastModifiedDateTime)
{
    public PantryItemResponse(Guid id, string name, double quantity, string unit, DateOnly expDate, string location, DateTime startDateTime, DateTime endDateTime) : this(id, name, quantity, unit, expDate, location, startDateTime, endDateTime, DateTime.Now)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Unit = unit;
        ExpDate = expDate;
        Location = location;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
    }
}
