using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groep9.NET.ViewModels {
    public class LogInViewModel {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }


        [Display(Name = "Gegevens omthouden?")]
        public bool RememberMe { get; set; }
    }
}