using jewllery_keep.Data;
using jewllery_keep.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jewllery_keep.Areas.Admin.Pages.Products
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AddModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _db.Products.Add(Product);
            _db.SaveChanges();

            // Redirect to the admin's product management page after adding
            return RedirectToPage("/ManageProducts", new { area = "Admin" });
        }
    }
}