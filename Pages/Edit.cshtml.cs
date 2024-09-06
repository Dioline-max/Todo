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
        public ToDo Todo { get; set; } = new ToDo();


        public void OnGet(string id)
        {
            Todo =  _context.Todos.Find(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var user = await _userManager.GetUserAsync(User);
            // user.ToDos.Add(Todo);
            Todo.User = user;
            Todo.OwnerID = user.Id;
            Todo.CreatedAt = DateTime.UtcNow;
            Todo.UpdatedAt = DateTime.UtcNow;
            await _context.Todos.AddAsync(Todo);
            await _context.SaveChangesAsync();
            return RedirectToPage("Display");
        }

        public async Task<IActionResult> OnPostEdit(string id)
        {
            
            var todo = _context.Todos.Find(id);
            todo.Title = Todo.Title;
            todo.Description = Todo.Description;
            _context.Todos.Update(todo);
            _context.SaveChanges();

            return RedirectToPage("Create");


        }
    }
}