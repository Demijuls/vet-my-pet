using VetMyPet.Models;

namespace VetMyPet.Data;

public static class SeedDatabase
{

  public static void PrepPopulation(IApplicationBuilder app)
  {
    using var serviceScope = app.ApplicationServices.CreateScope();
    SeedData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>());
  }

  private static void SeedData(AppDbContext context)
  {
    if (!context.Pets.Any())
    {
      AddPets(context);
    }
    context.SaveChanges();
  }

  private static void AddPets(AppDbContext context)
  {
    Console.WriteLine("Add pets to the empty database");

    context.Pets.AddRange(
         new Pet
         {
           PetId = "pet_21f68",
           Name = "Princess Donut",
           OwnerId = "owner_8fyw4",
           Weight = 4.8,
           ImageUrl = "https://static.wikia.nocookie.net/dungeon-crawler-carl/images/c/c8/Donut_by_Luciano_Fleitas.png/revision/latest/scale-to-width-down/1000?cb=20240311001951",
         },
         new Pet
         {
           PetId = "pet_4ruj54k",
           Name = "Mongo",
           OwnerId = "owner_8fyw4",
           Weight = 128.9,
           ImageUrl = "https://www.fossils-uk.com/blog/wp-content/uploads/2026/03/pexels-ayrat-244411276-28739080-1536x1024.jpg",
         },
          new Pet
          {
            PetId = "pet_9ur17s",
            Name = "Fluffy",
            OwnerId = "owner_8ry2t6",
            Weight = 14.2,
            ImageUrl = "https://images.unsplash.com/photo-1595017013941-cab3d4c8d02f?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=NHwxMjA3fDA%3D",
          }
    );

    context.Owners.AddRange(
      new Owner
      {
        OwnerId = "owner_8fyw4",
        Name = "Karl",
        Phone = "800-Goddamit-1",
      },
        new Owner
        {
          OwnerId = "owner_8ry2t6",
          Name = "Lucia",
          Phone = "800-ScaryShit-2",
        }
    );

    context.MedicalRecords.AddRange(
      new MedicalRecord
      {
        RecordId = "12345",
        PetId = "pet_21f68",
        Illness = "Too fabulous for that labirinth",
      },
        new MedicalRecord
        {
          RecordId = "67890",
          PetId = "pet_21f68",
          Illness = "I CAN TYPE HOWEVER I WANT, KARL",
        },
        new MedicalRecord
        {
          RecordId = "78901",
          PetId = "pet_9ur17s",
          Illness = "Are we sure it's a dog?",
        }
    );
  }

}