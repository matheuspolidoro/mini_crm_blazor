using System.ComponentModel.DataAnnotations;

namespace Mini_CRM_Blazor.Shared.Dtos
{
    public class CompanySubscriberCreateRequest
    {
        [Required]
        public string CompanyName { get; set; }
        public string? TradingName { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? AreaOfBusiness { get; set; }
        public string? Website { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        [EmailAddress]
        public string ManagerEmail { get; set; }

        public ICollection<ApplicationUserDto> AssociateMembers { get; set; } = new List<ApplicationUserDto>();
    }
}
