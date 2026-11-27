using Microsoft.EntityFrameworkCore;
using VetMyPet.Models;

namespace VetMyPet.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  public DbSet<Owner> Owners => Set<Owner>();
  public DbSet<Pet> Pets => Set<Pet>();
  public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();
}
