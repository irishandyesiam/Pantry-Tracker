using Microsoft.AspNetCore.Mvc;
using PantryTracker.Contracts.PantryItem;

namespace PantryTracker.Controllers;

[ApiController]
[Route("items")]
public class PantryTrackerController : ControllerBase
{
    [HttpPost()]
    public IActionResult CreateItem(CreatePantryItemRequest request)
    {
        return Ok(request);
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