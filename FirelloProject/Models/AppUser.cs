﻿using Microsoft.AspNetCore.Identity;

namespace FirelloProject.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
