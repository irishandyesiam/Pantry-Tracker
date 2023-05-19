namespace PantryTracker.Models;

public class PantryItem
{
    public Guid Id { get; }
    public string Name { get; }
    public double Quantity { get; }
    public string Unit { get; }
    public DateOnly ExpDate { get; }
    public string Location { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }

    public PantryItem(Guid id, string name, double quantity, string unit, DateOnly expDate, string location, DateTime startDateTime, DateTime endDateTime)
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
    }
}