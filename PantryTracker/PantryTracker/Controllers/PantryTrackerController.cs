using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using PantryTracker.Contracts.PantryItem;
using PantryTracker.Models;
using PantryTracker.Services.PantryItems;
using PantryTracker.ServiceErrors;

namespace PantryTracker.Controllers;

[ApiController]
[Route("items")]
public class PantryTrackerController : ControllerBase
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

        _pantryItemService.CreatePantryItem(item);

        var response = new PantryItemResponse(
            item.Id,
            item.Name,
            item.Quantity,
            item.Unit,
            item.ExpDate,
            item.Location,
            item.StartDateTime,
            item.EndDateTime,
            item.LastModifiedDateTime
        );

        return CreatedAtAction(
            actionName: nameof(GetItem),
            routeValues: new { id=item.Id },
            value: response
        );
    }



    [HttpGet("{id}")]
    public IActionResult GetItem(Guid id)
    {
        ErrorOr<PantryItem> getPantryItemResult = _pantryItemService.GetItem(id);

        if (getPantryItemResult.IsError &&
            getPantryItemResult.FirstError == Errors.PantryItem.NotFound)
        {
            return NotFound();
        }

        var pantryItem = getPantryItemResult.Value;

        var response = new PantryItemResponse(
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
        return Ok(response);
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
        _pantryItemService.DeleteItem(id);
        return NoContent();
    }
}