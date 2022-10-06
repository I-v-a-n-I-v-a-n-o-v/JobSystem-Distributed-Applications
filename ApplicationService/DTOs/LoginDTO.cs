using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }    
        public string TypeOfUser { get; set; }  
    }
}
