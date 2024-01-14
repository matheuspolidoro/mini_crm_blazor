using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_CRM_Blazor.Server.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid CompanySubscriberId { get; set; }
        [Required]
        public string? CompanyName { get; set; }
        public string? TradingName { get; set; }
        public string? Description { get; set; }
        [Required]
        public string AreaOfBusiness { get; set; }
        public string? Website { get; set; }
        public virtual ICollection<CustomerContact> CustomerContacts { get; set; } = new List<CustomerContact>();
        [ForeignKey("CompanySubscriberId")]
        public virtual CompanySubscriber CompanySubscriber { get; set; }
    }
}
