using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tp2_code_first
{
    class CinemaDbContext : DbContext
    {
        public CinemaDbContext() : base("name=MoviesDb") { }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
