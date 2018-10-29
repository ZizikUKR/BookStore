using Domain1.Abstract;
using Domain1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain1.Concret
{
    public class EFBookRepository : IBookRepository
    {
        EFDbContext db = new EFDbContext();
        public IEnumerable<Book> Books
        {
            get { return db.Books; }
        }

        public void SaveBook(Book book)
        {
            if (book.BookId == 0)
            {
                db.Books.Add(book);
            }
            else
            {
                Book dbEntry = db.Books.Find(book.BookId);
                if (dbEntry != null)
                {
                    dbEntry.Name = book.Name;
                    dbEntry.Description = book.Description;
                    dbEntry.Author = book.Author;
                    dbEntry.Price = book.Price;
                    dbEntry.Genre = book.Genre;
                }
            }
            db.SaveChanges();
        }
    }
}
