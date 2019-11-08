using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class DecodeMessageViewModel
    {
        [Display(Name = "N")]
        [Required(ErrorMessage = "Value N is required !")]
        [Range(2, int.MaxValue)]
        public int n { get; set; }

        [Display(Name = "D")]
        [Required(ErrorMessage = "Value D is required !")]
        [Range(2, int.MaxValue)]
        public int d { get; set; }

        //TODO: add here collection for coded numbers that will be decoded
    }
}