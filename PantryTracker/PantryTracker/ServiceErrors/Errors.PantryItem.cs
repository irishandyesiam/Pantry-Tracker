using ErrorOr;

namespace PantryTracker.ServiceErrors;

public static class Errors
{
    public static class PantryItem
    {
        public static Error NotFound => Error.NotFound(
            code: "PantryItem.NotFound",
            description: "Pantry item not found");
    }
}