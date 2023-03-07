using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class JouralismContext:DbContext
    {
        public DbSet<News> news { get; set; }
        public DbSet<NewDetails> newDetails { get; set; }
        public DbSet<Auther> authers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Jouralism;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
