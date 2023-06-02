using PantryTracker.Contracts.PantryItem;
using PantryTracker.ServiceErrors;
using ErrorOr;

namespace PantryTracker.Models;

public class PantryItem
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;

    public const int MinDescriptionLength = 50;
    public const int MaxDescriptionLength = 150;

    public Guid Id { get; }
    public string Name { get; }
    public double Quantity { get; }
    public string Unit { get; }
    public DateOnly ExpDate { get; }
    public string Location { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDateTime { get; }

    private PantryItem(Guid id, string name, double quantity, string unit, DateOnly expDate, string location, DateTime startDateTime, DateTime endDateTime, DateTime lastModifiedDateTime)
    {
        //enforce invariants: item names must be lowercase
        Id = id;
        Name = name;
        Quantity = quantity;
        Unit = unit;
        ExpDate = expDate;
        Location = location;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = LastModifiedDateTime;
    }
}