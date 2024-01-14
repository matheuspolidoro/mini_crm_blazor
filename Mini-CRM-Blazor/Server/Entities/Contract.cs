using Mini_CRM_Blazor.Shared.Enums;
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
                Status = (ContractStatuses)value;
            }
        }

        [EnumDataType(typeof(ContractStatuses))]
        public ContractStatuses Status { get; set; }
    }
}
