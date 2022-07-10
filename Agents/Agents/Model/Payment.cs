using Agents.DTO;

namespace Agents.Model
{
    public class Payment
    {
        public long CompanyId { get; set; }
        public long UserId { get; set; }
        public string JobPosition { get; set; }
        public double Price { get; set; }

        public JobPositionPayment JobPositionPayment { get; set; }
    }
}
