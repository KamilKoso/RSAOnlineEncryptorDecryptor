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
        [Range(2, int.MaxValue)]
        public int n { get; set; }

        [Required(ErrorMessage = "Value E is required !")]
        [Display(Name ="E")]
        [Range(2, int.MaxValue)]
        public int e { get; set; }

        [Display(Name ="Enter your message to encode")]
        [Required(ErrorMessage ="Enter your message to encode !")]
        public string message { get; set; }
    }
}