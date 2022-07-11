﻿using Agents.Model;
using System.Text.Json.Serialization;

namespace Agents.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }

        public bool Confirmed { get; set; }

        public string Password { get; set; }
    }
}
