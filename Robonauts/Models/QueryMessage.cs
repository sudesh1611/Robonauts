using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Robonauts.Models
{
    public class QueryMessage
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string Subject { get; set; }


        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "This field is required")]
        public string Message { get; set; }


        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = " Email is required")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Entered Email Address is not valid")]
        public string Email { get; set; }
    }
}
