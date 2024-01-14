using System.ComponentModel.DataAnnotations;

namespace Mini_CRM_Blazor.Shared.Dtos
{
    public class CustomerCreateRequest
    {
        [Required]
        public Guid CompanySubscriberId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string TradingName { get; set; }
        public string Description { get; set; }
        [Required]
        public string AreaOfBusiness { get; set; }
        public string Website { get; set; }
        public ICollection<CustomerContactDto> CustomerContacts { get; set; } = new List<CustomerContactDto>();
    }
}
