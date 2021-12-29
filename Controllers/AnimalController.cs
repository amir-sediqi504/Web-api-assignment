//A controller is a public class with one or more public methods known as actions.
using Animals.Models;
using Animals.Services;
using Microsoft.AspNetCore.Mvc;

namespace Animals.Controllers;

[Produces("application/json")]
[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase
{
    public AnimalController()
    {
    }

    
    [HttpGet]
public ActionResult<List<Animal>> GetAll() =>
    AnimalService.GetAll();

    
    [HttpGet("{id}")]
public ActionResult<Animal> Get(int id)
{
    var animal = AnimalService.Get(id);

    if(animal == null)
        return NotFound();

    return animal;
}

   
    [HttpPost]
public IActionResult Create(Animal animal)
{            
    AnimalService.Add(animal);
    return CreatedAtAction(nameof(Create), new { id = animal.Id }, animal);
}

   
    [HttpPut("{id}")]
public IActionResult Update(int id, Animal animal)
{
    if (id != animal.Id)
        return BadRequest();

    var existingAnimal = AnimalService.Get(id);
    if(existingAnimal is null)
        return NotFound();

    AnimalService.Update(animal);           

    return NoContent();
}

    
    [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var animal = AnimalService.Get(id);

    if (animal is null)
        return NotFound();

    AnimalService.Delete(id);

    return NoContent();
}
}