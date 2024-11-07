using Microsoft.EntityFrameworkCore;
using Mocan_Melisa_Lab2.Models;

namespace Mocan_Melisa_Lab2.Data
{
    public class Mocan_Melisa_Lab2Context : DbContext
    {
        public Mocan_Melisa_Lab2Context (DbContextOptions<Mocan_Melisa_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Mocan_Melisa_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Mocan_Melisa_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Mocan_Melisa_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Mocan_Melisa_Lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Mocan_Melisa_Lab2.Models.Member> Member { get; set; } = default!;
        public DbSet<Mocan_Melisa_Lab2.Models.Borrowing> Borrowing { get; set; } = default!;
    }
}
