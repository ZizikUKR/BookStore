using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain1.Entities
{
    public class Cart
    {
        private List<CartLine> lineColl = new List<CartLine>();
        public IEnumerable<CartLine> Lines { get { return lineColl; }  }

        public void AddItem(Book book, int quantity)
        {
            CartLine cartLine = lineColl.Where(p => p.Book.BookId == book.BookId).FirstOrDefault();
            if (cartLine == null)
            {
                lineColl.Add(new CartLine { Book = book, Quantity = quantity });
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }
        //Remove book from box
        public void RemoveLine(Book book)
        {
            lineColl.RemoveAll(p => p.Book.BookId == book.BookId);
        }
        //Calculate sum
        public decimal ComputeTotalValue()
        {
            return lineColl.Sum(p => p.Book.Price * p.Quantity);
        }
        //Clear the box
        public void Clear()
        {
            lineColl.Clear();
        }
    }
    public class CartLine
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
