using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManagementv2.Data;
using TaskManagementv2.Models;
using System.Threading.Tasks;

namespace TaskManagementv2.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly MyAppDbContext _context;

        public DeleteModel(MyAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Taasks Taasks { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Taasks = await _context.TaskDb.FirstOrDefaultAsync(m => m.TaskId == id);

            if (Taasks == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Taasks = await _context.TaskDb.FindAsync(id);

            if (Taasks != null)
            {
                _context.TaskDb.Remove(Taasks);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./taasks");
        }
    }
}
