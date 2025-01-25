using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManagementv2.Data;
using TaskManagementv2.Models;

namespace TaskManagementv2.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly MyAppDbContext _context;

        public CreateModel(MyAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Taasks Taasks { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TaskDb.Add(Taasks);
            await _context.SaveChangesAsync();

            return RedirectToPage("./taasks");
        }
    }
}
