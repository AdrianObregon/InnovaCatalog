﻿using Microsoft.EntityFrameworkCore;
using OnisCatalog.Orders.Models;

namespace OnisCatalog.Orders.DbContexts
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

       
        public DbSet<Usuario> Usuario { get; set; }


    }
}
