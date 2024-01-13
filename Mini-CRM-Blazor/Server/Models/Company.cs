namespace Mini_CRM_Blazor.Server.Models
{
    public class Company : EnterpriseModel
    { 
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

        public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}
