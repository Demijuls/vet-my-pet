using Microsoft.AspNetCore.Mvc;
using VetMyPet.Data;
using VetMyPet.Models;

namespace VetMyPet.Controllers
{
  public class PetsController : Controller
  {

    private readonly PetsController _petsController;
    public PetsController(PetsController petsController)
    { _petsController = petsController; }

    /// Index page for pets
    /// GET ALL

    /// GET one by id:
    public IActionResult Index(string petId)
    {
      var pet = _petsController.GetOne(petId);
      if (pet == null) return NotFound();
      return View(pet);
    }
    private string? GetOne(AppDbContext context, string petId)
    {
      context.Pets.FirstOrDefault(p => p.PetIdId == petId);
    }

    public void SaveChanges() => context.SaveChanges();
  }


  [HttpGet]

}
