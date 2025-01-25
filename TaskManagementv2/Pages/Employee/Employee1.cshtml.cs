using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManagementv2.Data;
using TaskManagementv2.Models;

namespace TaskManagementv2.Pages.Employee
{
    public class Employee1Model : PageModel
    {
        private readonly MyAppDbContext _context;

        public Employee1Model(MyAppDbContext context)
        {
            _context = context;
        }

        public IList<Taasks> Taasks { get; set; }

        public async Task OnGetAsync()
        {
            // Retrieve the currently logged-in user's name or identifier
            var currentUser = User.Identity.Name;

            // Filter tasks based on the logged-in user's assignments
            Taasks = await _context.TaskDb
                .Where(task => task.AssignedTo == "notuser")
                .ToListAsync();
        }
    }
}
