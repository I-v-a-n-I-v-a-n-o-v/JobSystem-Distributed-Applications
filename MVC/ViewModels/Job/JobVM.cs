using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class JobVM
    {
        public int Id { get; set; }

        [DisplayName("Title: ")]
        [Required]
        [MinLength(2), MaxLength(50)]
        public string Title { get; set; }

        [DisplayName("Description: ")]
        [MaxLength(280)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Choose a type:")]
        [DisplayName("Job type: ")]
        public string Type { get; set; }

        //[Required(ErrorMessage = "Choose a type:")]
        //[MaxLength(20)]
         //Part-Time/Full-Time/Remote

        [DisplayName("Organisation name: ")]
        [Required]
        [MaxLength(50)]
        public string Publisher { get; set; }//Organisation Name

        [DisplayName("Published on: ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedOn { get; set; }

        [DisplayName("Category: E.g. IT")]
        [MaxLength(30)]
        public string Category { get; set; }//E.g. IT

        public int OrganisationId { get; set; }

        public virtual ICollection<int> Candidates { get; set; } = null;

        public JobVM() {
            PublishedOn = DateTime.Now;    
        }

        public JobVM(JobDTO jobDTO)
        {
            Id = jobDTO.Id;
            Title = jobDTO.Title;
            Description = jobDTO.Description;
            Publisher = jobDTO.Publisher;
            PublishedOn = jobDTO.PublishedOn;
            Category = jobDTO.Category;
            OrganisationId = jobDTO.OrganisationId;
            Candidates = jobDTO.Candidates;
            Type = jobDTO.Type;
        }
    }
}