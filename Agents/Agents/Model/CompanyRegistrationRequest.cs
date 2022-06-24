namespace Agents.Model
{
    public class CompanyRegistrationRequest : Entity
    {
        public RequestStatus Status { get; private set; }

        public void Accept()
        {
            if (Status == RequestStatus.Waiting)
                Status = RequestStatus.Accepted;
        }

        public void Decline()
        {
            if (Status == RequestStatus.Waiting)
                Status = RequestStatus.Declined;
        }
    }
}
