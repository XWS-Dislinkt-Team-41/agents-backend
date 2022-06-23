using System.Text.Json.Serialization;
using Agents.Model;

namespace Agents.DTO
{
    public class UserDTO
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }

        public bool Confirmed { get; set; }

        //[JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
