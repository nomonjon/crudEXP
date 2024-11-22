using Microsoft.AspNetCore.Mvc;
using product.Data;
using product.Dtos.Car;
using product.Mappers;
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
        var cars = context.Cars.ToList()
            .Select(c => c.ToCarDto());
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
        return Ok(car.ToCarDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateCarRequestDto carDto)
    {
        var car = carDto.ToCarFromCreateDto();
        context.Cars.Add(car);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new {id = car.Id}, car.ToCarDto());
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateCarRequestDto updateDto)
    {
        var car = context.Cars.FirstOrDefault(c => c.Id == id);
        
        if(car == null)
            return NotFound();
        
        car.Brand = updateDto.Brand;
        car.Color = updateDto.Color;
        car.Model = updateDto.Model;
        car.Price = updateDto.Price;

        context.SaveChanges();
        return Ok(car.ToCarDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var car = context.Cars.FirstOrDefault(x => x.Id == id);
        
        if (car == null)
            return NotFound();

        context.Cars.Remove(car);
        context.SaveChanges();
        return NoContent();
    }
}