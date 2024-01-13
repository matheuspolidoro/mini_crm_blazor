﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_CRM_Blazor.Server.Models
{
    public class CustomerContact
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        
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