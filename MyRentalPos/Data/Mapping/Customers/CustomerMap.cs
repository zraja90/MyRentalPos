using System.Data.Entity.ModelConfiguration;
using MyRentalPos.Core.Domain.Customers;

namespace MyRentalPos.Data.Mapping.Customers
{
    public partial class CustomerMap : EntityTypeConfiguration<Customer>
    {

        public CustomerMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Address)
                .HasMaxLength(128);

            Property(t => t.City)
                .HasMaxLength(128);
            
            Property(t => t.CompanyName)
                .HasMaxLength(128);

            Property(t => t.Email)
                .HasMaxLength(128);

            Property(t => t.FirstName)
                .HasMaxLength(128);

            Property(t => t.LastName)
                .HasMaxLength(128);

            Property(t => t.PhoneNumber)
                .HasMaxLength(128);

            Property(t => t.State)
                .HasMaxLength(128);

            Property(t => t.StoreId);

            Property(t => t.ZipCode)
                .HasMaxLength(128);
            
            
            // Table & Column Mappings
            ToTable("Customer");
        }
    }
}
