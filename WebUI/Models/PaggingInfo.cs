using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class PaggingInfo
    {
        public int TottalItems { get; set; }//All amout of books
        public int ItemsPerPage { get; set; }//Amout books on the page
        public int CurrentPage { get; set; }// number of current page
        public int TotalPages {
            get { return (int)Math.Ceiling((decimal)TottalItems / ItemsPerPage); }
        }//All amout of pages


    }
}