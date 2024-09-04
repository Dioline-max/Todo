using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todo.AppDataContext;
using Todo.Contracts;
using Todo.Models;

namespace Todo.Pages
{
    public class SignUp : PageModel
    {

        private readonly UserManager<AppUser> _userManager;
        public SignUp(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty(SupportsGet=true)]
        public RegisterRequestDto registerRequestDto { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return StatusCode(500);
            var user = new AppUser
            {
                Email = registerRequestDto.Email,
                UserName = registerRequestDto.UserName
            };

            var createdUser = await _userManager.CreateAsync(user, registerRequestDto.Password);
            if(!createdUser.Succeeded)
            {
                return StatusCode(500,createdUser.Errors);
            }

            await _userManager.AddToRoleAsync(user, "User");
            return RedirectToPage("Login");
        }


    }
}