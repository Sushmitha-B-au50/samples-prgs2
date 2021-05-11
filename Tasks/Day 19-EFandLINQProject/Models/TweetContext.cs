using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFandLINQProject.Models
{
    class TweetContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Server=DESKTOP-8DSBI98\SQLEXPRESS;Integrated security= true;Database=dbTweet");
            }

        }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 1,
                PostText = "Test",
                Category ="Info"

            });
            
        }
    }

}
