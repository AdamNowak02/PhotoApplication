using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Data.Entities;


    namespace Data
    {
        public class AppDbContext : IdentityDbContext<IdentityUser>
        {

            private string DbPath { get; set; }
            public DbSet<PhotoEntity> Photos { get; set; }

            public DbSet<AparatEntity> Aparats { get; set; }
            public AppDbContext()
            {
                var folder = Environment.SpecialFolder.LocalApplicationData;
                var path = Environment.GetFolderPath(folder);
                DbPath = System.IO.Path.Join(path, "photos.db");
            }



            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<PhotoEntity>()
                    .HasOne(e => e.Aparat)
                    .WithMany(o => o.Photos)
                    .HasForeignKey(e => e.AparatId);

                // Remove the duplicate call to base.OnModelCreating(modelBuilder)
                // base.OnModelCreating(modelBuilder);

                PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();

                var user = new IdentityUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "andrzej",
                    Email = "andrzej@gmail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "ANDRZEJ@GMAIL.COM",
                    NormalizedUserName = "ANDRZEJ"
                };

                // Hash the password
                user.PasswordHash = ph.HashPassword(user, "Andrzej123!");

                modelBuilder.Entity<IdentityUser>()
                    .HasData(user);

                var user2 = new IdentityUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "adam",
                    Email = "adam@gmail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "ADAM@GMAIL.COM",
                    NormalizedUserName = "ADAM"
                };

                // Hash the password for user2
                user2.PasswordHash = ph.HashPassword(user2, "Adam123!");

                modelBuilder.Entity<IdentityUser>()
                    .HasData(user2);

                // Adding the administrator role
                var adminRole = new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "admin",
                    NormalizedName = "ADMIN"
                };

                adminRole.ConcurrencyStamp = adminRole.Id;
                modelBuilder.Entity<IdentityRole>()
                    .HasData(adminRole);

                // Adding the relationship between user2 and the admin role
                modelBuilder.Entity<IdentityUserRole<string>>()
                    .HasData(new IdentityUserRole<string>()
                    {
                        RoleId = adminRole.Id,
                        UserId = user2.Id
                    });



                modelBuilder.Entity<AparatEntity>().HasData(
                     new AparatEntity()
                     {
                         Id = 1,
                         Marka = "Nikon",
                         Model = "DX400",


                     },
                     new AparatEntity()
                     {
                         Id = 2,
                         Marka = "Sony",
                         Model = "AX1100",


                     },
                     new AparatEntity()
                     {
                         Id = 3,
                         Marka = "Kodak",
                         Model = "GD450",


                     }
                 ); ;
                modelBuilder.Entity<PhotoEntity>().HasData(
                   new PhotoEntity()
                   {
                       PhotoId = 1,
                       Opis = "Opis",
                       Autor = "Adam",
                       Format = "jpg",
                       Rozdzielczosc = "1280x720",
                       AparatId = 1,

                   },
                   new PhotoEntity()
                   {
                       PhotoId = 2,
                       Opis = "Opis",
                       Autor = "Tomasz",
                       Format = "png",
                       Rozdzielczosc = "1920x1080",
                       AparatId = 2,
                   },
                   new PhotoEntity()
                   {
                       PhotoId = 3,
                       Opis = "Opis",
                       Autor = "Adam",
                       Format = "png",
                       Rozdzielczosc = "720x480",
                       AparatId = 3,
                   }
               );

            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }

        }
    
}