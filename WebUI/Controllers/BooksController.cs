using Domain1.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class BooksController : Controller
    {
        public int pageSize = 4;
        private IBookRepository bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public ViewResult List(string genre, int page = 1)
        {
            BookListViewModel model = new BookListViewModel
            {
                Books = bookRepository.Books.Where(b => genre == null || b.Genre == genre).OrderBy(p => p.BookId).Skip((page - 1) * pageSize).Take(pageSize),
                PaggingInfo = new PaggingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TottalItems = genre == null ? bookRepository.Books.Count() : bookRepository.Books.Where(book => book.Genre == genre).Count()
                },
                CurrentGenre=genre
            };
            return View(model);
        }
    }
}