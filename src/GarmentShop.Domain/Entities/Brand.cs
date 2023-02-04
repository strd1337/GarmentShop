namespace GarmentShop.Domain.Entities; 
 
public partial class Brand
{
    public Guid BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
