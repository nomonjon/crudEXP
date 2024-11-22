namespace product.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;

public class Comment
{
    public int Id { get; set; }
    public string Title { get; set; } = "Rating";
    public string Content { get; set; } = "Bla Bla Bla";
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public int CarId { get; set; } 
    public Car? Car { get; set; }

}