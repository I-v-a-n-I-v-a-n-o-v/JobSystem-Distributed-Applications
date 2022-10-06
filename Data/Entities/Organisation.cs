using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Organisation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2),MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(90)]
        public string Email { get; set; }

        [Required]
        [MinLength(8),MaxLength(40)]
        public string Password { get; set; }
    }
}
