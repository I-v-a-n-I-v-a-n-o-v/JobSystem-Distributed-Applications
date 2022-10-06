﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class UserDTO: BaseDTO
    {
        [MaxLength(90)]
        public string Email { get; set; }

        [MinLength(3), MaxLength(50)]
        public string Username { get; set; }

        [MinLength(8), MaxLength(40)]
        public string Password { get; set; }

        public virtual ICollection<Job> JobsList { get; set; }
    }
}
