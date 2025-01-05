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
    public class DetailsModel : PageModel
    {
        private readonly Compilation.AppDbContext _context;

        public DetailsModel(Compilation.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
