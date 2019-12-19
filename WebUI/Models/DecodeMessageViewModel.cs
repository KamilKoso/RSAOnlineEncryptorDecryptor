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
        [Range(2, int.MaxValue, ErrorMessage = "Provided value is incorrect !")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Provided value is incorrect !")]
        public int n { get; set; }

        [Display(Name = "D")]
        [Required(ErrorMessage = "Value D is required !")]
        [Range(2, int.MaxValue, ErrorMessage = "Provided value is incorrect !")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Provided value is incorrect !")]
        public int d { get; set; }
        [Required]
        public string EncodedMessage { get; set; }


        public List<int> StringParser(string stringToParse)
        {
            //Splits values seperated by space, and adds it to the List<int>
            //in order to decode it in RSA

            List<int> list = new List<int>();
            string[] tab = stringToParse.Split(' ');
            int parsedValue;
            bool result = true;
            foreach (string str in tab)
            {
                if (!result)
                    return new List<int>();
               result=Int32.TryParse(str, out parsedValue);
                list.Add(parsedValue);
            }
            return list;    
        }
    }
}