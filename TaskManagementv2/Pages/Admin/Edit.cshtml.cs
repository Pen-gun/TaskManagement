using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManagementv2.Data;
using TaskManagementv2.Models;

namespace TaskManagementv2.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly MyAppDbContext _context;

        public EditModel(MyAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Taasks Taasks { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Taasks = await _context.TaskDb.FindAsync(id); 

            if (Taasks == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Taasks).State = EntityState.Modified;

            try
            {
                Taasks.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaasksExists(Taasks.TaskId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./taasks");
        }

        private bool TaasksExists(int id)
        {
            return _context.TaskDb.Any(e => e.TaskId == id);
        }
    }
}
