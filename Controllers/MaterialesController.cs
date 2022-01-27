using KALA.Models;
using KALA.Services;
using Microsoft.AspNetCore.Mvc;

namespace KALA.Controllers;

[ApiController]
[Route("[controller]")]
public class MaterialesController : ControllerBase
{
    public MaterialesController()
    {
    }

    [HttpGet]
    public ActionResult<List<Materiales>> GetAll() =>
        ServiciosVarios.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Materiales> Get(int id)
    {
        var materiales = ServiciosVarios.Get(id);

        if (materiales == null)
            return NotFound();

        return materiales;
    }

    [HttpPost]
    public IActionResult Create(Materiales materiales)
    {
        ServiciosVarios.Add(materiales);
        return CreatedAtAction(nameof(Create), new { id = materiales.Id }, materiales);

    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Materiales materiales)
    {
        if (id != materiales.Id)
            return BadRequest();

        var existingMaterial = ServiciosVarios.Get(id);
        if (existingMaterial is null)
            return NotFound();

        ServiciosVarios.Update(materiales);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var materiales = ServiciosVarios.Get(id);

        if (materiales is null)
            return NotFound();

        ServiciosVarios.Delete(id);

        return NoContent();
    }
}