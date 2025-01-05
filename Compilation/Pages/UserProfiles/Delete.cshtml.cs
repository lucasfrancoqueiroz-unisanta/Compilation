using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Compilation;
using Compilation.Models;

namespace Compilation.Pages.UserProfiles
{
    public class DeleteModel : PageModel
    {
        private readonly Compilation.AppDbContext _context;

        public DeleteModel(Compilation.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserProfile UserProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userprofile = await _context.UserProfiles.FirstOrDefaultAsync(m => m.Id == id);

            if (userprofile == null)
            {
                return NotFound();
            }
            else
            {
                UserProfile = userprofile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userprofile = await _context.UserProfiles.FindAsync(id);
            if (userprofile != null)
            {
                UserProfile = userprofile;
                _context.UserProfiles.Remove(UserProfile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
