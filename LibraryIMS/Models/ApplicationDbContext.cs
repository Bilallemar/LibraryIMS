using Microsoft.EntityFrameworkCore;

namespace LibraryIMS.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
    }
}
