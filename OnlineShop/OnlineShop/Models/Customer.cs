using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineShop.Models
{
    public class Customer
    {
        //This model gets all of the information from the customer and validates it 
        //Required = the user must enter this information
        //DisplayName = changing the name people will see whilst keeping it as the original name.
        //RegularExpressions = Bits of code that cancheck strings for certain things (good for validation)

         [Required(ErrorMessage = "First Name is Required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

         [Required(ErrorMessage = "Last Name is Required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

         [Required(ErrorMessage = "House Number is Required")]
        [DisplayName("House Number")]
        public int HouseNumber { get; set; }

         [Required(ErrorMessage = "Street Name is Required")]
        [DisplayName("Street Name")]
        public string StreetName { get; set; }

         [Required(ErrorMessage = "Town is Required")]
        public string Town { get; set; }

         [Required(ErrorMessage = "County is Required")]
        public string County { get; set; }
        
        [DisplayName("Post Code")]
        [Required(ErrorMessage = "Post Code is Required")]
        [RegularExpression("(GIR 0AA)|((([A-Z][0-9][0-9]?)|(([A-Z][A-Z][0-9][0-9]?)|(([A-Z][0-9][A-HJKSTUW])|([A-Z][A-Z][0-9][ABEHMNPRVWXY])))) [0-9][A-Z]{2})",
            ErrorMessage = "Invalid Post Code")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Card Number is Required")]
        [DisplayName("Card Number")]
        [RegularExpression(@"^(4|5)\d{3}-?\d{4}-?\d{4}-?\d{4}|(4|5)\d{15}|(^(6011)-?\d{4}-?\d{4}-?\d{4}(6011)-?\d{12})|(^((3\d{3}))-\d{6}-\d{5}|^((3\d{14})))", ErrorMessage="Invalid Card Number")]
        public int CardNumber { get; set; }
    }
}