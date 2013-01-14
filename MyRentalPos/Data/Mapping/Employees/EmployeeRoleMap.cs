using System.Data.Entity.ModelConfiguration;
using MyRentalPos.Core.Domain.Employees;

namespace MyRentalPos.Data.Mapping.Employees
{
    public partial class EmployeeRoleMap : EntityTypeConfiguration<EmployeeRole>
    {
        public EmployeeRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            Property(x => x.Active);

            // Properties
            // Table & Column Mappings
            this.ToTable("EmployeeRole");

            // Relationships
            this.HasMany(t => t.PermissionRecords)
                .WithMany(t => t.EmployeeRoles)
                .Map(m =>
                {
                    m.ToTable("PermissionRecord_Role_Mapping");
                    m.MapLeftKey("EmployeeRole_Id");
                    m.MapRightKey("PermissionRecord_Id");
                });
        }
    }
}