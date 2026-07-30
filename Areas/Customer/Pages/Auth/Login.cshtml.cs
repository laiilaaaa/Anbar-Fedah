using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
namespace jewllery_keep.Areas.Customer.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Password { get; set; }
        [BindProperty] public string? ReturnUrl { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("", "Email and Password are required.");
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(Email!, Password!, false, false);

            if (result.Succeeded)
                return LocalRedirect(ReturnUrl ?? "/Customer/Products");

            ModelState.AddModelError("", "Invalid login attempt.");
            return Page();
        }
    }
}