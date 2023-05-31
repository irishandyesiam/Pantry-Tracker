using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using PantryTracker.Contracts.PantryItem;
using PantryTracker.Models;
using PantryTracker.Services.PantryItems;
using PantryTracker.ServiceErrors;

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
        var item = new PantryItem(
            Guid.NewGuid(),
            request.Name,
            request.Quantity,
            request.Unit,
            request.ExpDate,
            request.Location,
            request.StartDateTime,
            request.EndDateTime,
            request.LastModifiedDateTime
        );

        ErrorOr<Created> createPantryItemResult = _pantryItemService.CreatePantryItem(item);

        if (createPantryItemResult.IsError)
        {
            return Problem(createPantryItemResult.Errors);
        }
        return CreatedAtAction(
            actionName: nameof(GetItem),
            routeValues: new { id=item.Id },
            value: MapPantryItemResponse(item)
        );
    }



    [HttpGet("{id}")]
    public IActionResult GetItem(Guid id)
    {
        ErrorOr<PantryItem> getPantryItemResult = _pantryItemService.GetItem(id);

        return getPantryItemResult.Match(
            pantryItem => Ok(MapPantryItemResponse(pantryItem)),
            errors => Problem(errors));
        // if (getPantryItemResult.IsError &&
        //     getPantryItemResult.FirstError == Errors.PantryItem.NotFound)
        // {
        //     return NotFound();
        // }

        // var pantryItem = getPantryItemResult.Value;

        // PantryItemResponse response = MapPantryItemResponse(pantryItem);
        // return Ok(response);
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
        
        _pantryItemService.UpsertItem(item);

        //TODO: return 201 if a new breakfast was created
        return NoContent();
    }

    [HttpDelete("{id.guid}")]
    public IActionResult DeleteItem(Guid id)
    {
        ErrorOr<Deleted> deletedResult = _pantryItemService.DeleteItem(id);
        
        return deletedResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }
}