﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTestBackendDev.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public Users()
        {
        }
    }
}