using Agents.DTO;

namespace Agents.Model
{
    public class Payment
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string JobPosition { get; set; }
        public double Price { get; set; }

        public JobPositionPayment JobPositionPayment { get; set; }
    }
}
