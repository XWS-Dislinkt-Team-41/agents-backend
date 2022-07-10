using System;

namespace Agents.Model
{
    public class CompanyRegistrationRequest : Entity
    {
        public RequestStatus Status { get; private set; }
        public long UserId { get; private set; }

        public String Name { get; set; }
        public string ContactInformation { get; private set; }
        public string ActivityDescription { get; private set; }

        public CompanyRegistrationRequest(long userId, string contactInformation, string activityDescription,String name)
        {
            Status = RequestStatus.Waiting;
            UserId = userId;
            ContactInformation = contactInformation;
            ActivityDescription = activityDescription;
            Name = name;
        }

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
