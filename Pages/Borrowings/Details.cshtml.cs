using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mocan_Melisa_Lab2.Data;
using Mocan_Melisa_Lab2.Models;

namespace Mocan_Melisa_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Mocan_Melisa_Lab2.Data.Mocan_Melisa_Lab2Context _context;

        public DetailsModel(Mocan_Melisa_Lab2.Data.Mocan_Melisa_Lab2Context context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing.Include(i=>i.Member).Include(b=>b.Book).ThenInclude(bc=>bc.Author).FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            else
            {
                Borrowing = borrowing;
            }
            return Page();
        }
    }
}
