﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMVCProject.Models
{
    public class PublicationContext : DbContext
    {
        //public PublicationContext(DbContextOptions option)
        public PublicationContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author() { Id = 1, Name = "Ram", About = "From India" }
                );

            modelBuilder.Entity<Book>().HasData(
                    new Book() { Id = 1, Title = "Frozen", Price = 450,Author_Id=1}
                    );
        }
    }
}
