using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todo.AppDataContext;
using Todo.Models;

namespace Todo.Pages
{
    public class Edit : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public Edit(ApplicationDbContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public ToDo Todo { get; set; }


        public IActionResult OnGet(string id)
        {
            Todo = _context.Todos.Find(id);
            if (Todo == null)
            {
                return BadRequest(500);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {

            var todo = _context.Todos.Find(id);
            todo.Title = Todo.Title;
            todo.Description = Todo.Description;
            _context.Todos.Update(todo);
            _context.SaveChanges();

            return RedirectToPage("Display");
        }

    }
}