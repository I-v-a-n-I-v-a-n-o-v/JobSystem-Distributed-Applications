using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class OrganisationDTO: BaseDTO
    {
        [MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(90)]
        public string Email { get; set; }

        [MinLength(8), MaxLength(40)]
        public string Password { get; set; }
    }
}
