using Microsoft.AspNetCore.Mvc;
using PantryTracker.Contracts.PantryItem;

namespace PantryTracker.Controllers;

[ApiController]
public class PantryTrackerController : ControllerBase
{
    [HttpPost("/items")]
    public IActionResult CreateItem(CreatePantryItemRequest request)
    {
        return Ok(request);
    }

    [HttpGet("/items/{id.guid}")]
    public IActionResult GetItem(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("/items/{id.guid}")]
    public IActionResult UpsertItem(Guid id, UpsertPantryItemRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("/items/{id.guid}")]
    public IActionResult DeleteItem(Guid id)
    {
        return Ok(id);
    }
}