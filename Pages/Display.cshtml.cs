using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todo.AppDataContext;
using Todo.Models;

namespace Todo.Pages
{
    public class Display : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public IEnumerable<ToDo> Todos { get; set; }
        public string UserName { get; set; }
        public Display(ApplicationDbContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            if (user != null)
            {
                UserName = user.UserName;
            }
            Todos = await _context.Todos.Where(t => t.OwnerID == user.Id).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(500);
            }
            var todo = await _context.Todos.FindAsync(id);
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return RedirectToPage("Display");
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToPage("Login");
        }

        // public async Task<IActionResult> OnPostEdit()
        // {
        //     return Re
        // }

       
    }
}