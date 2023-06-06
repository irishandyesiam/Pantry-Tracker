using ErrorOr;

namespace PantryTracker.ServiceErrors;

public static class Errors
{
    public static class PantryItem
    {
        public static Error InvalidName => Error.Validation(
            code: "PantryItem.InvalidName",
            description: $"PantryItem name must be at least {Models.PantryItem.MinNameLength}" +
                $" characters long and at most {Models.PantryItem.MaxNameLength} characters long.");
        
        public static Error InvalidDescription => Error.Validation(
            code: "PantryItem.InvalidDescription",
            description: $"PantryItem description must be at least {Models.PantryItem.MinDescriptionLength}" + 
                $" characters long and at most {Models.PantryItem.MaxDescriptionLength} characters long.");

        public static Error NotFound => Error.NotFound(
            code: "PantryItem.NotFound",
            description: "Pantry item not found");
    }
}