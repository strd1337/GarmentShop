namespace GarmentShop.Domain.Entities;

public partial class Color
{
    public Guid ColorId { get; set; }

    public string ColorName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
