using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {

            _builder.Entity<ArtProduct>(b =>
            {
                b.HasData(new ArtProduct
                {
                    ArtId = 1,
                    ArtName = "Mona Lisa",
                    ArtDesc = "Mona Lisa by Leanardo da Vinci",
                    ArtPrice = 2000,
                    ArtDimensions = "7*12",
                    ArtScore = 1500,
                    isAvailable = true,
                    imgBytes = File.ReadAllBytes($"Data/Images/Mona_Lisa.jpg"),
                });
                /*b.HasData(new ArtProduct
                {
                    ArtId = 2,
                    ArtName = "Harry Potter and the Chamber of Secrets",
                    ArtDesc = "Ever since Harry Potter had come home for the summer, the Dursleys had been so mean and hideous that all Harry wanted was to get back to the Hogwarts School for Witchcraft and Wizardry. ",
                    ArtPrice = 3000,
                    ArtDimensions = "7*12",
                    ArtScore = 20,
                    isAvailable = false,
                    imgBytes = new byte[0],
                });
                b.HasData(new ArtProduct
                {
                    ArtId = 3,
                    ArtName = "Steve Jobs",
                    ArtDesc = "Walter Isaacson’s “enthralling” (The New Yorker) worldwide bestselling biography of Apple cofounder Steve Jobs.",
                    ArtPrice = 4000,
                    ArtDimensions = "12*18",
                    ArtScore = 35,
                    isAvailable = true,
                    imgBytes = new byte[0],
                });*/
            });
        }
    }
}
