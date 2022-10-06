using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class JobDTO: BaseDTO
    {
        [Required]
        [MinLength(2), MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(280)]
        public string Description { get; set; }

        [MaxLength(20)]
        public string Type { get; set; } //Part-Time/Full-Time/Remote

        [Required]
        [MaxLength(50)]
        public string Publisher { get; set; }//Organisation Name

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedOn { get; set; }

        [MaxLength(30)]
        public string Category { get; set; }//E.g. IT

        public int OrganisationId { get; set; }

        public virtual ICollection<int> Candidates { get; set; } = null;
    }
}
