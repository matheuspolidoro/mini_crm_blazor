using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_CRM_Blazor.Shared.Dtos
{
    public class CustomerContactCreateRequest
    {
        [Required]
        public Guid CustomerId { get; set; }
        public string? PersonResponsibleName { get; set; }
        public string? Sector { get; set; }

        [Required]
        public string ContactInfo { get; set; }
        [Required]
        public int TypeContactId { get; set; }
    }
}
