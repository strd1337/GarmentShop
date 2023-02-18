using GarmentShop.Domain.Common.Models;

namespace GarmentShop.Domain.SaleAggregate.ValueObjects
{
    public sealed class Invoice : ValueObject
    {
        public decimal TotalCost { get; private set; }
        public decimal Tax { get; private set; }
        public decimal ShippingAndHandling { get; private set; }
        public decimal OtherCharges { get; private set; }

        private Invoice(
            decimal totalCost,
            decimal tax,
            decimal shippingAndHandling,
            decimal otherCharges)
        {
            TotalCost = totalCost;
            Tax = tax;
            ShippingAndHandling = shippingAndHandling;
            OtherCharges = otherCharges;
        }

        public static Invoice CreateNew(
            decimal totalCost,
            decimal tax,
            decimal shippingAndHandling,
            decimal otherCharges)
        {
            return new(
                totalCost,
                tax,
                shippingAndHandling,
                otherCharges);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return TotalCost;
            yield return Tax;
            yield return ShippingAndHandling;
            yield return OtherCharges;
        }

#pragma warning disable CS8618
        private Invoice()
        {
        }
#pragma warning restore CS8618
    }
}
