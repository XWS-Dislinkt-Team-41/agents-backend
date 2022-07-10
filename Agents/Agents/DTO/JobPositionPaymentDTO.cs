using Agents.Model;

namespace Agents.DTO
{
    public class JobPositionPaymentDTO : Entity
    {
        public int CompanyId { get; set; }

        public string NameOfPosition { get; set; }
        public double Price { get; set; }
    }
}

