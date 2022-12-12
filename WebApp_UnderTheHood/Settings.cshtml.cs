using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp_UnderTheHood
{
    [Authorize(Policy = "AdminOnly")]
    public class Settings : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}