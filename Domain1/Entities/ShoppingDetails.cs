using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain1.Entities
{
    public class ShoppingDetails
    {
        [Required(ErrorMessage ="Enter Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Order Adress")]
        [Display(Name="First Adress")]
        public string Line1 { get; set; }
        [Display(Name = "Second Andress")]
        public string Line2 { get; set; }
        [Display(Name = "Third Adresss")]
        public string Line3 { get; set; }

        [Required(ErrorMessage ="Enter the city")]
        public string City { get; set; }

        [Required(ErrorMessage ="Enter the country")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
