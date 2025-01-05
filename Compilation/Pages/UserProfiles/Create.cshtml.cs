using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Compilation;
using Compilation.Models;

namespace Compilation.Pages.UserProfiles
{
    public class CreateModel : PageModel
    {
        private readonly Compilation.AppDbContext _context;

        public CreateModel(Compilation.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserProfile UserProfile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserProfiles.Add(UserProfile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
