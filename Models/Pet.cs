using System.ComponentModel.DataAnnotations;

namespace VetMyPet.Models;

public class Pet
{
  [Key]
  public required string PetId { get; set; }
  public required string Name { get; set; }
  public required string OwnerId { get; set; }
  public Owner? Owner { get; set; }
  public double Weight { get; set; }
  public string? ImageUrl { get; set; }
  public List<MedicalRecord> MedicalRecords { get; set; } = [];
}