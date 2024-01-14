using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_CRM_Blazor.Server.Models
{
    public class AssociateMember
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public String ApplicationUserId { get; set; }
        [Required]
        public Guid CompanySubscriberId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }


        [ForeignKey("CompanySubscriberId")]
        public virtual CompanySubscriber CompanySubscriber { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
