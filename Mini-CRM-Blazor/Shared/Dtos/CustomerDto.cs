using Mini_CRM_Blazor.Shared.Dtos;

namespace Mini_CRM_Blazor.Shared.Models
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public Guid CompanySubscriberId { get; set; }
        public string CompanyName { get; set; }
        public string TradingName { get; set; }
        public string Description { get; set; }
        public string AreaOfBusiness { get; set; }
        public string Website { get; set; }
        public ICollection<CustomerContactDto> CustomerContacts { get; set; } = new List<CustomerContactDto>();

    }
}

