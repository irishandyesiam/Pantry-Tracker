using Microsoft.AspNetCore.Mvc;
using PantryTracker.Contracts.PantryItem;
using PantryTracker.Models;

namespace PantryTracker.Controllers;

[ApiController]
[Route("items")]
public class PantryTrackerController : ControllerBase
{
    [HttpPost]
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
        return Ok(id);
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