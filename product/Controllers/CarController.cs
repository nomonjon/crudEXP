using Microsoft.AspNetCore.Mvc;
using product.Data;
using product.Models;

namespace product.Controller;

[Route("product/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ApplicationDbContext context;
    public CarController(ApplicationDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var cars = context.Cars.ToList();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var car = context.Cars.Find(id);
        if (car == null)
        {
            return NotFound();
        }
        return Ok(car);
    }


    [HttpPost]
        public IActionResult CreateCar([FromBody] Car car)
        {
            car.Id = Guid.NewGuid();
            if (car == null)
            {
                return BadRequest("Car data is null.");
            }

            // Add the car to the database
            context.Cars.Add(car);
            context.SaveChanges();  // Synchronous call to save changes

            // Return the created car with HTTP 201 status
            return CreatedAtAction(nameof(GetById), new { id = car.Id }, car);
        }
}