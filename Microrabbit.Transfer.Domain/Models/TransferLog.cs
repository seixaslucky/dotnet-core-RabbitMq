namespace Microrabbit.Transfer.Domain.Models
{
    public class TransferLog
    {
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public decimal Amount { get; set; }
    }
}
