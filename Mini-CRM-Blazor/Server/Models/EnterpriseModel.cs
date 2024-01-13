using System.ComponentModel.DataAnnotations;

namespace Mini_CRM_Blazor.Server.Models
{
    public class EnterpriseModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string TradingName { get; set; }
        public string Description { get; set; }
        [Required]
        public string AreaOfBusiness { get; set; }
        public string Website { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public virtual ICollection<EnterpriseContact> EnterpriseContacts { get; set; } = new List<EnterpriseContact>();
    }
}
