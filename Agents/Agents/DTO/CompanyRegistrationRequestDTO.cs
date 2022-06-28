using Agents.Model;

namespace Agents.DTO
{
    public class CompanyRegistrationRequestDTO
    {
        public long Id { get; set; }
        public RequestStatus Status { get; set; }
        public long UserId { get; set; }
        public string ContactInformation { get; set; }
        public string ActivityDescription { get; set; }
    }
}
