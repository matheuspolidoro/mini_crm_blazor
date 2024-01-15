using System;
using System.Collections.Generic;
namespace Mini_CRM_Blazor.Shared.Dtos
{
    public class SupplierDto
    {
        public Guid Id { get; set; }
        public Guid CompanySubscriberId { get; set; }
        public string CompanyName { get; set; }
        public string TradingName { get; set; }
        public string Description { get; set; }
        public string AreaOfBusiness { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
