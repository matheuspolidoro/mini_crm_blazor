namespace Mini_CRM_Blazor.Shared.Dtos
{
    public class ContractDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Guid AssociateMemberId { get; set; }
        public string AssociateMemberName { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
    }
}
