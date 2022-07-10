using Agents.Model;

namespace Agents.DTO
{
    public class PaymentDTO
    {
        public long CompanyId { get; set; }
        public long UserId { get; set; }
        public string JobPosition { get; set; }
        public double Price { get; set; }

        public JobPositionPayment JobPositionPayment { get; set; }
    }
}
