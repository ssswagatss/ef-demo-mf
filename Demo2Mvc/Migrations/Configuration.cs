﻿namespace Demo2Mvc.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Demo2Mvc.Models.DemoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Demo2Mvc.Models.DemoDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            if (!context.Employees.Any())
            {
                context.Employees.Add(new Models.Employee
                {
                    Age = 21,
                    EmailAddress = "swagat@gmail.com",
                    FullName = "Swagat Swain"
                });
                context.Employees.Add(new Models.Employee
                {
                    Age = 22,
                    EmailAddress = "rohit@gmail.com",
                    FullName = "Rohit"
                });
                context.Employees.Add(new Models.Employee
                {
                    Age = 12,
                    EmailAddress = "rahul@gmail.com",
                    FullName = "Rahul"
                });
                context.SaveChanges();
            }

            if (!context.Departments.Any())
            {
                context.Departments.Add(new Models.Department {
                    DepartmentName="HR",
                    Location="BBSR"
                });
                context.Departments.Add(new Models.Department
                {
                    DepartmentName = "Admin",
                    Location = "CTC"
                });
                context.SaveChanges();
            }
        }
    }
}
