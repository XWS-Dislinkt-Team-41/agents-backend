﻿using System;

namespace Agents.Model
{
    public class User:Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }

        public bool Confirmed { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

    }
}
