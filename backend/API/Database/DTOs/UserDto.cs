﻿using System.ComponentModel.DataAnnotations;

namespace API.Database.DTOs
{
    public class UserDto
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
