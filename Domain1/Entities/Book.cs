using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain1.Entities
{
    public class Book 
    {
        [HiddenInput(DisplayValue =false)]        
        public int BookId { get; set; }

        [Required(ErrorMessage ="Pleas enter the name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pleas enter the Athor's name")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Pleas enter the description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Pleas enter the genre")]
        public string Genre { get; set; }

        [Display(Name="Price (grn)")]
        [Required]
        [Range(0.01,double.MaxValue, ErrorMessage = "Pleas enter the positive price")]
        public decimal Price { get; set; }
    }
}
