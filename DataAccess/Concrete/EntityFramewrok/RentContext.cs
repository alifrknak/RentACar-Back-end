using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramewrok
{
    public class RentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ReCar;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        //Entity Framework ORM Yaklaşımı

        public DbSet<Car>? Cars { get; set; }

        public DbSet<Brand>? Brands { get; set; }

        public DbSet<Color>? Colors { get; set; }

        public DbSet<Rental>? Rentals { get; set; }

        public DbSet<User>? Users { get; set; }

        public DbSet<Customer>? Customers { get; set; }

        public DbSet<CarImage>? CarImages { get; set; }

        public DbSet<OperationClaim>? OperationClaims { get; set; }

        public DbSet<UserOperationClaim>? UserOperationClaims { get; set; }

    }
}