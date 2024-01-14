using Mini_CRM_Blazor.Shared.Dtos;

namespace Mini_CRM_Blazor.Shared.Models
{
    public class CompanySubscriberDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string TradingName { get; set; }
        public string Description { get; set; }
        public string AreaOfBusiness { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<AssociateMemberDto> AssociateMembers { get; set; } = new List<AssociateMemberDto>();
        public ICollection<CustomerDto> Customers { get; set; } = new List<CustomerDto>();
        public ICollection<SupplierDto> Suppliers { get; set; } = new List<SupplierDto>();

    }
}

