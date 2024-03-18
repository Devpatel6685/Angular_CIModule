﻿using System;
using System.Collections.Generic;

namespace CIPlatform.DAL.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public long Phone { get; set; }
        public string StreetAddress { get; set; } = null!;
        public string? City { get; set; }
        public string? State { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
