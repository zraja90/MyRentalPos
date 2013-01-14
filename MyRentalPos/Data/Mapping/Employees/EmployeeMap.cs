using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Employees;

namespace MyRentalPos.Data.Mapping.Employees
{
    public class EmployeeMap: EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            Property(x => x.Active);
            Property(x => x.UserName);
            Property(x => x.Email);
            Property(x => x.FirstName);
            Property(x => x.LastName);
            Property(x => x.Password);
            // Properties
            // Table & Column Mappings
            this.ToTable("Employee");

            //Relationships
            HasMany(x=>x.EmployeeRoles)
                .WithMany(x=>x.Employees)
                .Map(m =>
                         {
                             m.ToTable("Employee_EmployeeRole_Mapping");
                             m.MapLeftKey("Employee_Id");
                             m.MapRightKey("EmployeeRole_Id");
                         }
                );
            HasRequired(x => x.Store)
                .WithMany(t => t.Employees)
                .HasForeignKey(x => x.StoreId);
        }
    }
}