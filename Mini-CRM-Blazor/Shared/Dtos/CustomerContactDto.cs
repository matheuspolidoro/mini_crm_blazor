using System.ComponentModel.DataAnnotations.Schema;
using Mini_CRM_Blazor.Shared.Enums;

namespace Mini_CRM_Blazor.Shared.Dtos
{
    public class CustomerContactDto
    {
        public Guid Id { get; set; }
        public string ContactInfo { get; set; }
        public string? PersonResponsibleName { get; set; }
        public string? Sector { get; set; }
        public TypeContacts TypeContact { get; set; }
    }
}
