using Domain1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PaggingInfo PaggingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}