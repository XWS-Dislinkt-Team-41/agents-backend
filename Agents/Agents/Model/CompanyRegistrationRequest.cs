namespace Agents.Model
{
    public class CompanyRegistrationRequest : Entity
    {
        public RequestStatus Status { get; private set; }
        public long UserId { get; private set; }
        public long CompanyId { get; private set; }
        public Company Company { get; private set; }

        public bool Accept()
        {
            if (Status != RequestStatus.Waiting) return false;
            Status = RequestStatus.Accepted;
            return true;
        }

        public bool Decline()
        {
            if (Status != RequestStatus.Waiting) return false;
            Status = RequestStatus.Declined;
            return true;
        }
    }
}
