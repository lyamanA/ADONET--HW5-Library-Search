using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ADONET__HW5_Library_Search
{
    internal class LibraryContext : DbContext
    {

        string connectionString = ConfigurationManager
             .ConnectionStrings["DefaultConnectionString"]
             .ConnectionString;

        public DbSet<Authors> authors {  get; set; }

        public DbSet<Book> books { get; set; }

        public DbSet<Categories> categories { get; set; }

        public DbSet<Themes> themes { get; set; }

        public LibraryContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
