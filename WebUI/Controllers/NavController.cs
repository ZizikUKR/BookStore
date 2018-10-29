using Domain1.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private IBookRepository repository;
        public NavController(IBookRepository repository)
        {
            this.repository = repository;

        }
       public PartialViewResult Menu(string genre = null)
        {
            ViewBag.SelectedGanre = genre;
            IEnumerable<string> genres = repository.Books.
                Select(p => p.Genre).Distinct().OrderBy(x => x);
            return PartialView(genres);
        }
    }
}