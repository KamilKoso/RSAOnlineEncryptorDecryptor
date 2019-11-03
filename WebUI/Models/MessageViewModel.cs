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
        public int n { get; set; }
        [Display(Name ="E")]
        public int e { get; set; }
        [Display(Name ="D")]
        public int d { get; set; }
        [Display(Name ="Enter your message to encode")]
        public string message { get; set; }
    }
}