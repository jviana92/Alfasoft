using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Alfasoft.Pages.Account;

[AllowAnonymous]
public class LoginModel : PageModel
{
    [BindProperty]
    public Credentials credentials{ get; set; }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) return Page();

        if (credentials.Username == "admin" && credentials.Password == "password")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "admin")
            };
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

            return RedirectToPage("/Index");
        }
        return Page();
    }
}

public class Credentials
{
    [Required]
    public string? Username{ get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password{ get; set; }
}
