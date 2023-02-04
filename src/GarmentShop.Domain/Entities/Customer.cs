namespace GarmentShop.Domain.Entities;

public partial class Customer
{
    public Guid CustomerId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; } = new List<CustomerAddress>();

    public virtual CustomerPersonalDetail? CustomerPersonalDetail { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
