using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2),MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(280)]
        public string Description { get; set; }

        [MaxLength(20)]
        public string Type { get; set; } //Part-Time/Full-Time/Remote

        [Required]
        [MaxLength(50)]
        public string Publisher { get; set; }//Organisation Name

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedOn { get; set; }

        [MaxLength(30)]
        public string Category { get; set; }//E.g. IT

        //Foreign Key for 'Organisation' table
        //[ForeignKey("OrganisationId")]
        public int OrganisationId { get; set; }

        public virtual Organisation Organisation { get; set; }

        public virtual ICollection<int> Candidates { get; set; } = null; //Collection of Users Id that are applied for the current job
    }
}
