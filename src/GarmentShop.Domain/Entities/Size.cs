namespace GarmentShop.Domain.Entities;

public partial class Size
{
    public Guid SizeId { get; set; }

    public string SizeName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
