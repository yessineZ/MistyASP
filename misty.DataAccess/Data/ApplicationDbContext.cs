using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using misty.Models;
using MistyASP.DataAccess.Data;

namespace MistyASP.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>{
        //ctor and tab to create the methode AppDbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {


            
        }
        public DbSet<Catergory> catergories { get; set; }
        public DbSet<Etudiant> etudiants { get; set; }
        public DbSet<Game> Games{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder); 
            
            modelBuilder.Entity<Catergory>().HasData(
                new Catergory { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Catergory { Id = 2, Name = "History", DisplayOrder = 2 },
                new Catergory { Id = 3, Name = "Math", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Game>().HasData(
               new Game {
                   Id = 1,
                   Title = "Fortune of Time",
                   Author = "Billy Spark",
                   Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                   ISBN = "SWD9999001",
                   CategoryId = 1,
                   Price = 90,
                  
               },
                new Game {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
					CategoryId = 2,
					Price = 30,
                    
                },
                new Game {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
					CategoryId = 2,
					Price = 50,
                   
                },
                new Game {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
					CategoryId = 2,
					Price = 65,
                 
                },
                new Game {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
					CategoryId = 1,
					Price = 27,
                    
                },
                new Game {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
					CategoryId = 1,
					Price = 23,
                   
                }
               );


        }


         
    
    }
}
