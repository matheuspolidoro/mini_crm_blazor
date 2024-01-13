using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mini_CRM_Blazor.Server.Models;

namespace Mini_CRM_Blazor.Server.DAL
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<CompanySubscriber> CompanySubscribers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<AssociateMember> AssociateMembers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
    }
}
