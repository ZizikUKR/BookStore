namespace Domain1.Concret
{
    using Domain1.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EFDbContext : DbContext
    {
       public DbSet<Book> Books { get; set; }
    }
}