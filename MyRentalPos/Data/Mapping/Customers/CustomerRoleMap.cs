using System.Data.Entity.ModelConfiguration;
using MyRentalPos.Core.Domain.Customers;

namespace MyRentalPos.Data.Mapping.Customers
{
    public partial class CustomerRoleMap : EntityTypeConfiguration<CustomerRole>
    {
        public CustomerRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("CustomerRole");

            // Relationships
            this.HasMany(t => t.PermissionRecords)
                .WithMany(t => t.CustomerRoles)
                .Map(m =>
                {
                    m.ToTable("PermissionRecord_Role_Mapping");
                    m.MapLeftKey("CustomerRole_Id");
                    m.MapRightKey("PermissionRecord_Id");
                });


        }
    }
}