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
    public class IndexModel : PageModel
    {
        private readonly Compilation.AppDbContext _context;

        public IndexModel(Compilation.AppDbContext context)
        {
            _context = context;
        }

        public IList<UserProfile> UserProfile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            UserProfile = await _context.UserProfiles.ToListAsync();
        }
    }
}
