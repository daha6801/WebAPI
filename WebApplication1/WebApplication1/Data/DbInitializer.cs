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
                    ArtId = Guid.NewGuid(),
                    ArtName = "Birth of Venus",
                    ArtDesc = "Birth of Venus is a renaissance style painting by Botticelli. It was painted in 1485. ",
                    ArtPrice = 4000,
                    ArtDimensions = "172.5 x 278.5 cm",
                    ArtScore = 35,
                    isAvailable = true,
                    imgBytes = new byte[0],
                });
            });

            _builder.Entity<User>(b =>
            {
                b.HasData(new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john_test@gmail.com",
                    Phone = "612-666-1234",
                    IsAdmin = true,
                });
                b.HasData(new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "jane_test@gmail.com",
                    Phone = "612-666-3456",
                    IsAdmin = false,
                });
            });
        }
    }
}
