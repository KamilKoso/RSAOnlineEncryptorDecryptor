using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class MessageViewModel
    {
        [Display(Name ="N")]
        [Required(ErrorMessage = "Value N is required !")]
        [Range(2, int.MaxValue, ErrorMessage ="Provided value is incorrect !")]
        [RegularExpression("([2-9][0-9]*)", ErrorMessage = "Provided value is incorrect !")]
        public int n { get; set; }

        [Required(ErrorMessage = "Value N is required !")]
        [Range(2, int.MaxValue, ErrorMessage = "Provided value is incorrect !")]
        [RegularExpression("([2-9][0-9]*)", ErrorMessage = "Provided value is incorrect !")]
        [Display(Name ="E")]
        public int e { get; set; }

        [Display(Name ="Enter your message to encode")]
        [Required(ErrorMessage ="Enter your message to encode !")]
        public string message { get; set; }
    }
}