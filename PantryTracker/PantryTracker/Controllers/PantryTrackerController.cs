using Microsoft.AspNetCore.Mvc;
using PantryTracker.Contracts.PantryItem;
using PantryTracker.Models;
using PantryTracker.Services.PantryItems;

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
            request.EndDateTime
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
            item.EndDateTime
        );

        return CreatedAtAction(
            actionName: nameof(GetItem),
            routeValues: new { id=item.Id },
            value: response
        );
    }

    [HttpGet("{id.guid}")]
    public IActionResult GetItem(Guid id)
    {
        PantryItem pantryItem = _pantryItemService.GetItem(id);

        var response = new PantryItemResponse(
            pantryItem.Id,
            pantryItem.Name,
            pantryItem.Quantity,
            pantryItem.Unit,
            pantryItem.ExpDate,
            pantryItem.Location,
            pantryItem.StartDateTime,
            pantryItem.EndDateTime
        );
        return Ok(response);
    }

    [HttpPut("{id.guid}")]
    public IActionResult UpsertItem(Guid id, UpsertPantryItemRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id.guid}")]
    public IActionResult DeleteItem(Guid id)
    {
        return Ok(id);
    }
}