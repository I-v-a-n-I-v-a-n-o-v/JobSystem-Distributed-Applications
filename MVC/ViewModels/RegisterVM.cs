using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class RegisterVM
    {
        [DisplayName("Email: ")]
        [Required(ErrorMessage = "This field is Required!")]
        [StringLength(90, MinimumLength = 8)]
        public string Email { get; set; }

        [DisplayName("Password: ")]
        [Required(ErrorMessage = "This field is Required!")]
        [StringLength(40, MinimumLength = 8)]
        public string Password { get; set; }

        //[DisplayName("Organisation name: ")]
        [Required(ErrorMessage = "This field is Required!")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public string TypeOfUser { get; set; } = "0";
    }
}