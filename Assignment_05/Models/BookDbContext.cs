﻿using System;
using Microsoft.EntityFrameworkCore;

namespace Assignment_05.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base (options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
