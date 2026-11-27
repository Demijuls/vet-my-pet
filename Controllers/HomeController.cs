using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetMyPet.Data;
using VetMyPet.Models;

namespace VetMyPet.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    { _context = context; }

    public IActionResult Index()
    {
        var pets = _context.Pets.Include(o => o.Owner).Include(mr => mr.MedicalRecords).ToList();

        return View(pets);
    }

    public IActionResult PetDetails(string petId)
    {
        var petDetails = _context.Pets.Include(o => o.Owner).Include(mr => mr.MedicalRecords).FirstOrDefault(id => id.PetId == petId);

        if (petDetails == null)
        {
            return NotFound();
        }

        return View(petDetails);
    }

    [HttpGet]
    public IActionResult AddPet()
    {
        ViewBag.Owners = _context.Owners.ToList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddPet(CreatePetRequest request)
    {
        if (!_context.Owners.Any(o => o.OwnerId == request.OwnerId))
        {
            ModelState.AddModelError("", "Please choose an existing owner.");
            ViewBag.Owners = _context.Owners.ToList();
            return View();
        }

        var pet = new Pet
        {
            PetId = $"pet_{Guid.NewGuid().ToString("N")[..8]}",
            Name = request.Name,
            OwnerId = request.OwnerId,
            Weight = request.Weight,
            ImageUrl = request.ImageUrl,
        };

        _context.Pets.Add(pet);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
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

    public record CreatePetRequest(string Name, string OwnerId, double Weight, string? ImageUrl);
}
