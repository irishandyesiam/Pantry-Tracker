using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using PantryTracker.Contracts.PantryItem;
using PantryTracker.Models;
using PantryTracker.Services.PantryItems;

namespace PantryTracker.Controllers;

public class PantryTrackerController : ApiController
{
    private readonly IPantryItemService _pantryItemService;

    public PantryTrackerController(IPantryItemService pantryItemService)
    {
        _pantryItemService = pantryItemService;
    }

    [HttpPost]
    [ActionName(nameof(CreateItem))]
    public IActionResult CreateItem(CreatePantryItemRequest request)
    {
        ErrorOr<PantryItem> requestToPantryItemResult = PantryItem.From(request);

        if (requestToPantryItemResult.IsError)
        {
            return Problem(requestToPantryItemResult.Errors);
        }
        var item = requestToPantryItemResult.Value;
        ErrorOr<Created> createPantryItemResult = _pantryItemService.CreatePantryItem(item);

        return createPantryItemResult.Match(
            created => CreatedAtGetItem(item),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public IActionResult GetItem(Guid id)
    {
        ErrorOr<PantryItem> getPantryItemResult = _pantryItemService.GetItem(id);

        return getPantryItemResult.Match(
            pantryItem => Ok(MapPantryItemResponse(pantryItem)),
            errors => Problem(errors));
    }

    [HttpPut("{id}")]
    public IActionResult UpsertItem(Guid id, UpsertPantryItemRequest request)
    {
        var item = new PantryItem(
            id,
            request.Name,
            request.Quantity,
            request.Unit,
            request.ExpDate,
            request.Location,
            request.StartDateTime,
            request.EndDateTime,
            request.LastModifiedDateTime);
        
        ErrorOr<UpsertedPantryItem> upsertedPantryItemResult = _pantryItemService.UpsertItem(item);

        return upsertedPantryItemResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetItem(item) : NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id.guid}")]
    public IActionResult DeleteItem(Guid id)
    {
        ErrorOr<Deleted> deletedPantryItemResult = _pantryItemService.DeleteItem(id);
        
        return deletedPantryItemResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

private static PantryItemResponse MapPantryItemResponse(PantryItem pantryItem)
    {
        return new PantryItemResponse(
            pantryItem.Id,
            pantryItem.Name,
            pantryItem.Quantity,
            pantryItem.Unit,
            pantryItem.ExpDate,
            pantryItem.Location,
            pantryItem.StartDateTime,
            pantryItem.EndDateTime,
            pantryItem.LastModifiedDateTime
        );
    }

  private CreatedAtActionResult CreatedAtGetItem(PantryItem pantryItem)
    {
        return CreatedAtAction(
                actionName: nameof(GetItem),
                routeValues: new { id=pantryItem.Id },
                value: MapPantryItemResponse(pantryItem)
            );
    }
}