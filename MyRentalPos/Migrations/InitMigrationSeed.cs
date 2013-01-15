using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Core.Domain.Email;
using MyRentalPos.Core.Domain.Employees;
using MyRentalPos.Core.Domain.Security;
using MyRentalPos.Core.Domain.Stores;
using MyRentalPos.Core.Domain.Tasks;
using MyRentalPos.Data;

namespace MyRentalPos.Migrations
{
    public class InitMigrationSeed
    {
        public static void Seed(AppContext context)
        {
            InitPermissions(context);
            InitCustomers(context);
            InitStore(context);
            InitEmailAccount(context);
            InitScheduleTask(context);
            InitEmployee(context);
        }

        private static void InitEmployee(AppContext context)
        {
            var settings = new List<Employee>
                               {
                                   new Employee
                                       {
                                           StoreId = 1,
                                           UserName = "zee",
                                           Active = true,
                                           CreatedDate = DateTime.UtcNow,
                                           Email = "me@a.com",
                                           FirstName = "John",
                                           LastName = "Smith",
                                           LastActivityDateUtc = DateTime.UtcNow,
                                           LastLoginDateUtc = DateTime.UtcNow,
                                           Password = "AJr8zm5tyOB2NDsch4xx5u17SmJTS1DPOjjBQ4m6FJJSxxcBSSkQXAHGhCgyUKIL5A=="
                                       }
                               };
            if (!context.Set<Employee>().Any())
            {
                settings.ForEach(x=>context.Set<Employee>().AddOrUpdate(x));
            }
            context.SaveChanges();
        }

        private static void InitStore(AppContext context)
        {
            var settings = new List<Store>
                               {
                                   new Store
                                       {
                                           BaseUrl = "http://localhost:53646",
                                           Email = "zraja90@gmail.com",
                                           StoreName = "My Rental Pos",
                                           IsActive = true,
                                           Image = "",
                                           IsGlobal = true,
                                           LogOutUrl = "http://localhost:53646",
                                           Owner = "Zeeshan Raja"
                                       }
                               };
            if (!context.Set<Store>().Any())
            {
                settings.ForEach(x => context.Set<Store>().Add(x));
            }
            context.SaveChanges();
        }

        private static void InitScheduleTask(AppContext context)
        {
            var settings = new List<ScheduleTask>
                               {
                                   new ScheduleTask
                                       {
                                           Name = "Send Emails",
                                           Seconds = 60,
                                           Type = "ToolDepot.Services.Email.QueuedMessagesSendTask, ToolDepot",
                                           Enabled = true,
                                           StopOnError = false,
                                           LastStartUtc = null,
                                           LastEndUtc = null,
                                           LastSuccessUtc = null
                                       },
                                   new ScheduleTask
                                       {
                                           Name = "Keep alive",
                                           Seconds = 300,
                                           Type = "ToolDepot.Services.Common.KeepAliveTask, ToolDepot",
                                           Enabled = true,
                                           StopOnError = false,
                                           LastStartUtc = null,
                                           LastEndUtc = null,
                                           LastSuccessUtc = null
                                       }
                               };
            if (!context.Set<ScheduleTask>().Any())
            {
                settings.ForEach(x => context.Set<ScheduleTask>().Add(x));
            }
            context.SaveChanges();
        }

        private static void InitEmailAccount(AppContext context)
        {
            var settings = new List<EmailAccount>
                               {
                                   new EmailAccount
                                       {
                                           DisplayName = "Tool Depot",
                                           Email = "zeeshan@unigo.com",
                                           Host = "127.0.0.1",
                                           Port = 25,
                                           EnableSsl = false,
                                           IsDefault = true,
                                           Username = "zeeshan@unigo.com",
                                           Password = "aa",
                                           UseDefaultCredentials = true
                                       }
                               };
            if (!context.Set<EmailAccount>().Any())
            {
                settings.ForEach(x => context.Set<EmailAccount>().Add(x));
            }
            context.SaveChanges();
        }


        private static void InitCustomers(AppContext context)
        {
            var customer = new Customer()
            {
                CompanyName = "My Rental Pos",
                Email = "guest@myrentalpos.com",
                //Password = "AJr8zm5tyOB2NDsch4xx5u17SmJTS1DPOjjBQ4m6FJJSxxcBSSkQXAHGhCgyUKIL5A==",
                FirstName = "Guest",
                LastName = "User",
                StoreId=1,
                ZipCode = "",
                Address = "",
                City = "",
                PhoneNumber = "",
                State = ""
            };


            if (context.Set<Customer>().Any())
                return;

            context.Set<Customer>().AddOrUpdate(customer);

            context.SaveChanges();
        }

        private static void InitPermissions(AppContext context)
        {

            var settings = new List<PermissionRecord>
                               {
                                   new PermissionRecord
                                       {
                                           Name = "Access admin area",
                                           SystemName = "AccessAdminPanel",
                                           Category = "Standard"
                                       }
                               };
            if (!context.Set<PermissionRecord>().Any())
            {
                settings.ForEach(x => context.Set<PermissionRecord>().Add(x));
            }


            context.SaveChanges();

        }


    }
}