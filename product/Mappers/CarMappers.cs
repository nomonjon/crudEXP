using product.Dtos.Car;
using product.Models;
namespace product.Mappers;

public static class CarMappers
{
    public static CarDto ToCarDto(this Car carModel)
    {
        return new CarDto
        {
            Id = carModel.Id,
            Brand = carModel.Brand,
            Model = carModel.Model,
            Color = carModel.Color,
            Price = carModel.Price
        };
    }

    public static Car ToCarFromCreateDto(this CreateCarRequestDto carDto)
    {
        return new Car
        {
            Brand = carDto.Brand,
            Model = carDto.Model,
            Color = carDto.Color,
            Price = carDto.Price
        };
    }
}