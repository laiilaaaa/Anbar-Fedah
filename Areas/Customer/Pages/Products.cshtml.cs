using Microsoft.AspNetCore.Mvc.RazorPages;
using jewllery_keep.Data;
using jewllery_keep.Models; // needed for Product
using System.Collections.Generic;
using System.Linq;

namespace jewllery_keep.Areas.Customer.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ProductsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> Products { get; set; } = new();

        public void OnGet(string? query)
        {
            var productQuery = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                productQuery = productQuery.Where(p => p.Name.Contains(query));
            }

            Products = productQuery.ToList();
        }
    }
}