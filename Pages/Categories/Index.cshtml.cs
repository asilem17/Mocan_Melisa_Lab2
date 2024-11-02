using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mocan_Melisa_Lab2.Data;
using Mocan_Melisa_Lab2.Models;
using Mocan_Melisa_Lab2.Models.ViewModels;

namespace Mocan_Melisa_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Mocan_Melisa_Lab2.Data.Mocan_Melisa_Lab2Context _context;

        public IndexModel(Mocan_Melisa_Lab2.Data.Mocan_Melisa_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;
        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
            .Include(b => b.BookCategories)
            .ThenInclude(bc => bc.Book)
            .ThenInclude(c => c.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();
            if (id.HasValue)
            {
                CategoryID = id.Value;

                var selectedCategory = CategoryData.Categories
                    .SingleOrDefault(c => c.ID == id.Value);

                if (selectedCategory != null)
                {
                    CategoryData.Books = selectedCategory.BookCategories
                        .Select(bc => bc.Book)
                        .ToList();
                }
            }
        }
    }
}