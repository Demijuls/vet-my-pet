using System.ComponentModel.DataAnnotations;

namespace VetMyPet.Models;

public class MedicalRecord
{
  [Key]
  public required string RecordId { get; set; }
  public required string PetId { get; set; }
  public required Pet? Pet { get; set; }
  public required string Illness { get; set; }
}