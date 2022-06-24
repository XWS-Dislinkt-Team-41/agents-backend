using Agents.Model;

namespace Agents.DTO
{
    public class CompanyRegistrationRequestDTO
    {
        public long Id { get; set; }
        public RequestStatus Status { get; set; }
        public long UserId { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
