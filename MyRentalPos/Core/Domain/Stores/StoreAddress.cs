namespace MyRentalPos.Core.Domain.Stores
{
    public class StoreAddress : BaseEntity
    {
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
    }
}