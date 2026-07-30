//ManageProducts.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using jewllery_keep.Data;
using Microsoft.AspNetCore.Authorization;
using jewllery_keep.Models;
using System.Collections.Generic;
using System.Linq;

namespace jewllery_keep.Areas.Admin.Pages
{
    [Authorize(Roles = "Admin")]
    public class ManageProductsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ManageProductsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> Products { get; set; } = new();

        public void OnGet()
        {
            Products = _context.Products.ToList();
        }
    }
}