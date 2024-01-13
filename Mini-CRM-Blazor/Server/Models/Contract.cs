using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_CRM_Blazor.Server.Models
{
    public class Contract
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [ForeignKey("CustomerId")] 
        public virtual Customer Customer { get; set; }
        
        [Required]
        public Guid AssociateMemberId { get; set; }

        [ForeignKey("AssociateMemberId")]
        public virtual AssociateMember AssociateMember { get; set; }

        [Required]
        public virtual int StatusId
        {
            get
            {
                return (int)this.Status;
            }
            set
            {
                Status = (Statuses)value;
            }
        }

        [EnumDataType(typeof(Statuses))]
        public Statuses Status { get; set; }
        
        public enum Statuses
        {
            Leads = 0,
            SalesCall = 1,
            FollowUp = 2,
            Conversion = 3,
            Sale = 4
        }
    }
}
