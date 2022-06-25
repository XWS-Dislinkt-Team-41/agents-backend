namespace Agents.DTO
{
    public class PaymentDTO
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string JobPosition { get; set; }
        public double Price { get; set; }

        public JobPositionPaymentDTO jobPositionPaymentDTO { get; set; }
    }
}
