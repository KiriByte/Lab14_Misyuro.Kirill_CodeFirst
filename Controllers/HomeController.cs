using System.Diagnostics;
using Lab14_Misyuro.Kirill_CodeFirst.Context;
using Lab14_Misyuro.Kirill_CodeFirst.Entities;
using Microsoft.AspNetCore.Mvc;
using Lab14_Misyuro.Kirill_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab14_Misyuro.Kirill_CodeFirst.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DbContextOptions<MyDbContext> _context;


    public HomeController(ILogger<HomeController> logger,DbContextOptions<MyDbContext> context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        using (MyDbContext db = new MyDbContext(_context))
        {
            Book book1 = new Book { Name = "qwerty", Price = 123 };
            Book book2 = new Book { Name = "dvorak", Price = 267 };
            Book book3 = new Book { Name = "colemak", Price = 125 };

            db.Books.Add(book1);
            db.Books.Add(book2);
            db.Books.Add(book3);

            db.SaveChanges();
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}