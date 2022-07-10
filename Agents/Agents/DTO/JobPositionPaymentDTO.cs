using Agents.Model;

namespace Agents.DTO
{
    public class JobPositionPaymentDTO : Entity
    {
        public long CompanyId { get; set; }

        public string NameOfPosition { get; set; }
        public double Price { get; set; }
    }
}

