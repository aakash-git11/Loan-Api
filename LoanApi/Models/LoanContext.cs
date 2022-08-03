using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApi.Models
{
    public class LoanContext:DbContext
    {
        public LoanContext(DbContextOptions<LoanContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<LoanDetails> LoanDetails { get; set; }

        protected void onModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<LoanDetails>().ToTable("LoanDetails");
        }
    }
}
