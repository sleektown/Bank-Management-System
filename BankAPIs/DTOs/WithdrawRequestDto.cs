namespace BankAPIs.DTOs
{
    public class WithdrawRequestDto
    {
        public required string AccountNumber { get; set; }
        public required decimal Amount { get; set; }

    }
}
