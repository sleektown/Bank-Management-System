using Bank_Management_System.Enums;
namespace BankAPIs.DTOs
{
    public class TransactionResponseDto
    {
        public Guid TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionTime { get; set; }

        public decimal BalanceBeforeTransaction { get; set; }

        public decimal BalanceAfterTransaction { get; set; }

    }
}
