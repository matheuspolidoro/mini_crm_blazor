using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_CRM_Blazor.Server.Models
{
    public class ApplicationUser : IdentityUser
    {

        public Guid? CompanySubscriberId { get; set; }

        [ForeignKey("CompanySubscriberId")]
        public virtual CompanySubscriber? CompanySubscriber { get; set; }
        public string? Position { get; set; }
    }
}
