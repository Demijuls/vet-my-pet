using System.ComponentModel.DataAnnotations;

namespace VetMyPet.Models;

public class Owner
{
  [Key]
  public required string OwnerId { get; set; }
  public required string Name { get; set; }
  public required string Phone { get; set; }
  public List<Pet> Pets { get; set; } = [];
}