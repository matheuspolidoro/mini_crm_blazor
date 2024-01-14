
namespace Mini_CRM_Blazor.Shared.Dtos
{
    public class ApplicationUserDto
    {
        public Guid Id { get; set; }
        public String ApplicationUserId { get; set; }
        public Guid CompanySubscriberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
    }
}
