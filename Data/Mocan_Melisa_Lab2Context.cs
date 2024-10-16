using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
