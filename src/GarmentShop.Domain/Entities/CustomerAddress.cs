namespace GarmentShop.Domain.Entities;

public partial class CustomerAddress
{
    public Guid AddressId { get; set; }

    public Guid CustomerId { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string AddressLine2 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
