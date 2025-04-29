using Labb_3___API.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;

namespace Labb_3___API.DataContext
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<MtmInterest> PersonInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MtmInterest>()
                .HasKey(pi => new { pi.PersonId, pi.InterestId });

            modelBuilder.Entity<MtmInterest>()
                .HasOne(pi => pi.Person)
                .WithMany(p => p.PersonInterests)
                .HasForeignKey(pi => pi.PersonId);

            modelBuilder.Entity<MtmInterest>()
                .HasOne(pi => pi.Interest)
                .WithMany(i => i.PersonInterests)
                .HasForeignKey(pi => pi.InterestId);

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Anna Andersson", Phone = "0701234567" },
                new Person { Id = 2, Name = "Bertil Berg", Phone = "0739876543" },
                new Person { Id = 3, Name = "Cecilia Carlsson", Phone = "0761122334" },
                new Person { Id = 4, Name = "David Dahl", Phone = "0709876543" },
                new Person { Id = 5, Name = "Eva Eriksson", Phone = "0734567890" },
                new Person { Id = 6, Name = "Fredrik Frisk", Phone = "0765432109" },
                new Person { Id = 7, Name = "Gina Gustavsson", Phone = "0701234567" },
                new Person { Id = 8, Name = "Henrik Hansson", Phone = "0739876543" }
            );

            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Name = "Fotboll", Description = "Spela och titta på fotboll" },
                new Interest { Id = 2, Name = "Musik", Description = "Spela gitarr och lyssna på musik" },
                new Interest { Id = 3, Name = "Programmering", Description = "Utveckla applikationer och hemsidor" },
                new Interest { Id = 4, Name = "Resa", Description = "Besöka nya länder och kulturer" },
                new Interest { Id = 5, Name = "Matlagning", Description = "Laga och njuta av god mat" },
                new Interest { Id = 6, Name = "Fotografi", Description = "Ta bilder och redigera dem" },
                new Interest { Id = 7, Name = "Träning", Description = "Hålla sig i form och träna" },
                new Interest { Id = 8, Name = "Litteratur", Description = "Läsa böcker och skriva" },
                new Interest { Id = 9, Name = "Film", Description = "Titta på filmer och serier" },
                new Interest { Id = 10, Name = "Spel", Description = "Spela datorspel och brädspel" },
                new Interest { Id = 11, Name = "Konst", Description = "Skapa och uppskatta konstverk" },
                new Interest { Id = 12, Name = "Natur", Description = "Vandra och njuta av naturen" }
            );

            modelBuilder.Entity<MtmInterest>().HasData(
                new MtmInterest { PersonId = 1, InterestId = 1 },
                new MtmInterest { PersonId = 1, InterestId = 2 },
                new MtmInterest { PersonId = 2, InterestId = 3 },
                new MtmInterest { PersonId = 2, InterestId = 4 },
                new MtmInterest { PersonId = 3, InterestId = 5 },
                new MtmInterest { PersonId = 3, InterestId = 6 },
                new MtmInterest { PersonId = 4, InterestId = 2 },
                new MtmInterest { PersonId = 4, InterestId = 7 },
                new MtmInterest { PersonId = 5, InterestId = 8 },
                new MtmInterest { PersonId = 5, InterestId = 9 },
                new MtmInterest { PersonId = 6, InterestId = 10 },
                new MtmInterest { PersonId = 6, InterestId = 11 },
                new MtmInterest { PersonId = 7, InterestId = 12 },
                new MtmInterest { PersonId = 7, InterestId = 1 },
                new MtmInterest { PersonId = 8, InterestId = 3 },
                new MtmInterest { PersonId = 8, InterestId = 5 }
            );

            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, Url = "https://www.fotbollskanalen.se/", PersonId = 1, InterestId = 1 },
                new Link { Id = 2, Url = "https://open.spotify.com/", PersonId = 1, InterestId = 2 },

                new Link { Id = 3, Url = "https://csharpskolan.se/borja-har/", PersonId = 2, InterestId = 3 },
                new Link { Id = 4, Url = "https://www.trivago.se/", PersonId = 2, InterestId = 4 },

                new Link { Id = 5, Url = "https://www.kitchenlab.se/k/matlagning/", PersonId = 3, InterestId = 5 },
                new Link { Id = 6, Url = "https://www.gotaplatsensfoto.se/", PersonId = 3, InterestId = 6 },

                new Link { Id = 7, Url = "https://tidal.com/", PersonId = 4, InterestId = 2 },
                new Link { Id = 8, Url = "https://www.actic.se/", PersonId = 4, InterestId = 7 },

                new Link { Id = 9, Url = "https://litteraturbanken.se/", PersonId = 5, InterestId = 8 },
                new Link { Id = 10, Url = "https://www.netflix.com/se/", PersonId = 5, InterestId = 9 },

                new Link { Id = 11, Url = "https://store.steampowered.com/", PersonId = 6, InterestId = 10 },
                new Link { Id = 12, Url = "https://konst.se", PersonId = 6, InterestId = 11 },

                new Link { Id = 13, Url = "https://www.sverigesnatur.org/", PersonId = 7, InterestId = 12 },
                new Link { Id = 14, Url = "https://allsvenskan.se/", PersonId = 7, InterestId = 1 },

                new Link { Id = 15, Url = "https://www.javascript.com/", PersonId = 8, InterestId = 3 },
                new Link { Id = 16, Url = "https://www.gordonramsay.com/", PersonId = 8, InterestId = 5 }
            );
        }
    }
    
  
}
