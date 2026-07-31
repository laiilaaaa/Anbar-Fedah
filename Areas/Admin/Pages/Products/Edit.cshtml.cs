using jewllery_keep.Data;
using jewllery_keep.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jewllery_keep.Areas.Admin.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Product Product { get; set; } = null!;

        public IActionResult OnGet(int id)
        {
            var product = _db.Products.Find(id);

            if (product == null)
                return RedirectToPage("/ManageProducts", new { area = "Admin" });

            Product = product;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var existing = _db.Products.Find(Product.Id);
            if (existing == null)
                return RedirectToPage("/ManageProducts", new { area = "Admin" });

            existing.Name = Product.Name;
            existing.Description = Product.Description;
            existing.Price = Product.Price;
            existing.ImageUrl = Product.ImageUrl;
            existing.Stock = Product.Stock;

            _db.SaveChanges();

            return RedirectToPage("/ManageProducts", new { area = "Admin" });
        }
    }
}
