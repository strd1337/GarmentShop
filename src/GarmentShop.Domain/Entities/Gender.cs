namespace GarmentShop.Domain.Entities;

public partial class Gender
{
    public Guid GenderId { get; set; }

    public string GenderName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
