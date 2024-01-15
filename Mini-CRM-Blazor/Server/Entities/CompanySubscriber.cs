using System.ComponentModel.DataAnnotations;

namespace Mini_CRM_Blazor.Server.Models
{
    public class CompanySubscriber
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? CompanyName { get; set; }
        public string? TradingName { get; set; }
        public string? Description { get; set; }
        [Required]
        public string AreaOfBusiness { get; set; }
        public string? Website { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<ApplicationUser>? ApplicationUsers { get; set; } = new List<ApplicationUser>();
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}
