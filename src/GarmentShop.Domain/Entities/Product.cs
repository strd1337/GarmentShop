namespace GarmentShop.Domain.Entities;

public partial class Product
{
    public Guid ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string Image { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public string ManufacturerCountry { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public Guid BrandId { get; set; }

    public Guid GenderId { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual ICollection<Color> Colors { get; } = new List<Color>();

    public virtual ICollection<Size> Sizes { get; } = new List<Size>();
}
