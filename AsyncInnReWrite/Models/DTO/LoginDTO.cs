﻿using System.ComponentModel.DataAnnotations;
 
namespace AsyncInnReWrite.Models.DTO
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
