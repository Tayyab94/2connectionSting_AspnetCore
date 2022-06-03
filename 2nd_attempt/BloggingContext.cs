using c_string_demo.Models;
using Microsoft.EntityFrameworkCore;

namespace c_string_demo._2nd_attempt
{
    public abstract partial class BloggingContext<T> :DbContext where T : DbContext
    {
        private readonly string _connectionString;

        protected BloggingContext(string conntectionString) => _connectionString = conntectionString;
        
        protected BloggingContext(DbContextOptions<T> options) : base(options) { }

        public virtual DbSet<Student> Students { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

    }
}
