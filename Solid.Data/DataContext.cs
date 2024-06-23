using Gifts;
using Microsoft.EntityFrameworkCore;
using Solid.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Opinion> Opinions { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Events1> Events11 { get; set; }
        public DbSet<Categry> Categrys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Gifts1");
        }


    }
}
