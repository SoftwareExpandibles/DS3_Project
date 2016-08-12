using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Data.Models;
using Data;
using Models;
using Rangamo.Models; 

namespace Data.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string postal { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<Product> Products { get; set; }
        public System.Data.Entity.DbSet<Genre> Genres { get; set; }
        public System.Data.Entity.DbSet<Size> Sizes { get; set; }
        public System.Data.Entity.DbSet<Employee> Employees { get; set; }
        public System.Data.Entity.DbSet<Supplier> Suppliers { get; set; }
        public System.Data.Entity.DbSet<Inventory> Inventories { get; set; }
        public System.Data.Entity.DbSet<Warehouse> Warehouses { get; set; }
        public System.Data.Entity.DbSet<File> Files { get; set; }
        public System.Data.Entity.DbSet<messages> messages { get; set; }
        public System.Data.Entity.DbSet<Job> Jobs { get; set; }
        public System.Data.Entity.DbSet<Applicant> Applicants { get; set; }
        public DbSet<ReOrderRequest> ReOrderRequests { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DailyReOrderCounters> DailyReOrderCounter { get; set; }
        public DbSet<DailyOrderCounters> DailyOrderCounter { get; set; }
        public DbSet<MonthlyOrderCounters> MonthlyOrderCounter { get; set; }
        public DbSet<MonthlyReOrderCounters> MonthlyReOrderCounter { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public System.Collections.IEnumerable Sms { get; set; }
    }
}