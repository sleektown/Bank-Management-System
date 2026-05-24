namespace BankAPIs.DTOs
{
    public class DepositRequestDto
    {
        public required string AccountNumber { get; set; }
        public required decimal Amount { get; set; }
    }
}
