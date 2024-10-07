using Microsoft.EntityFrameworkCore;

namespace DESAISIV.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}
