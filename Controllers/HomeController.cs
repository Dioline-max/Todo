using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.AppDataContext;
using Todo.Models;

namespace Todo.Controllers;

public class HomeController : Controller
{
    // private readonly ApplicationDbContext _context;
    // public HomeController(ApplicationDbContext context)
    // {
    //     _context = context;
    // }
    public  IActionResult Display()
    {
        return View();
    }

}
