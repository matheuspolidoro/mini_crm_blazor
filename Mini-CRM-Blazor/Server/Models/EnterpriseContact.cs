using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_CRM_Blazor.Server.Models
{
    public class EnterpriseContact
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid EnterpriseId { get; set; }
        
        [ForeignKey("EnterpriseId")]
        public virtual EnterpriseModel Enterprise  { get; set; }
        
        [Required]
        public string ContactInfo { get; set; }
        [Required]
        public virtual int TypeContactId
        {
            get
            {
                return (int)this.TypeContact;
            }
            set
            {
                TypeContact = (TypeContacts)value;
            }
        }

        [EnumDataType(typeof(TypeContacts))]
        public TypeContacts TypeContact { get; set; }

        public enum TypeContacts
        {
            Email = 0,
            PhoneNumber = 1
        }
    }
}
