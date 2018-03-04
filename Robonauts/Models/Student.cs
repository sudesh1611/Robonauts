using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Robonauts.Models
{
    public class Student
    {

        public int ID { get; set; }

        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage ="Choose an option")]
        public string Course { get; set; }

        [Required(ErrorMessage = "Choose an option")]
        public string Year { get; set; }

        [DataType(DataType.PhoneNumber)]
        [MaxLength(10, ErrorMessage = "Entered Phone Number is not Valid")]
        [Required(ErrorMessage = "Phone Number is Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered Phone Number format is not valid")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = " Email is required")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Entered Email Address is not valid")]
        public string Email { get; set; }
    }
}
