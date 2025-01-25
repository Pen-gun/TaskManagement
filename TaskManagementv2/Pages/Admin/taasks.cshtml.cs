using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManagementv2.Data;
using TaskManagementv2.Models;

namespace TaskManagementv2.Pages.Admin
{
    public class taasksModel : PageModel
    {
        private readonly MyAppDbContext _context;

        public taasksModel(MyAppDbContext context)
        {
            _context = context;
        }
        public IList<Taasks> Taasks { get; set; }

        public async Task OnGetAsync()
        {
            Taasks = await _context.TaskDb.ToListAsync();
        }
    }
}
