using Domain1.Abstract;
using Domain1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private IBookRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IBookRepository repository, IOrderProcessor orderProcessor)
        {
            this.orderProcessor = orderProcessor;
            this.repository = repository;
        }

        //public Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CarIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart( Cart cart,int bookid, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(p => p.BookId == bookid);
            if (book != null)
            {
                cart.AddItem(book,1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int bookid, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(p => p.BookId == bookid);
            if (book != null)
            {
                cart.RemoveLine(book);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            return View(new ShoppingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShoppingDetails shoppingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, box is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.Processor(cart, shoppingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(new ShoppingDetails());
            }
        }
    }
}