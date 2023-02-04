namespace GarmentShop.Domain.Entities;

public partial class CustomerPersonalDetail
{
    public Guid CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
