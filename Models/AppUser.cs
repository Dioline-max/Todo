using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Todo.Models
{
    public class AppUser : IdentityUser
    {
        public string? FirstName {get; set;}
        public string? LastName { get; set; }       
        public ICollection<ToDo>? ToDos { get; set; }
    }
}