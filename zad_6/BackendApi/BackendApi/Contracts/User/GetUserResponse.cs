﻿using System;

namespace BackendApi.Contracts.User
{
    public class GetUserResponse
    {
        // name email phone password\
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public string Role { get; set; } = null;
        public string Email { get; set; } = null;
        public string Phone { get; set; } = null;
        public string Password { get; set; } = null;
    }
}
