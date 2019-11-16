using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class DecodeMessageViewModel
    {
        [Required]
        public int n { get; set; }
        [Required]
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