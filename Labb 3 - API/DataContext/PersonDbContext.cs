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
                .HasOne(pi => pi.Person)
                .WithMany(p => p.MtmInterest)
                .HasForeignKey(pi => pi.PersonId);

            modelBuilder.Entity<MtmInterest>()
                .HasOne(pi => pi.Interest)
                .WithMany(i => i.MtmInterest)
                .HasForeignKey(pi => pi.InterestId);

            // Persons
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, FirstName = "Anna", LastName = "Andersson", Phone = "0701234567" },
                new Person { Id = 2, FirstName = "Bertil", LastName = "Berg", Phone = "0739876543" },
                new Person { Id = 3, FirstName = "Cecilia", LastName = "Carlsson", Phone = "0761122334" },
                new Person { Id = 4, FirstName = "David", LastName = "Dahl", Phone = "0709876543" },
                new Person { Id = 5, FirstName = "Eva", LastName = "Eriksson", Phone = "0734567890" },
                new Person { Id = 6, FirstName = "Fredrik", LastName = "Frisk", Phone = "0765432109" },
                new Person { Id = 7, FirstName = "Gina", LastName = "Gustavsson", Phone = "0701234567" },
                new Person { Id = 8, FirstName = "Henrik", LastName = "Hansson", Phone = "0739876543" }
            );

            // Interests
            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, IntrestName = "Fotboll", Description = "Spela och titta på fotboll" },
                new Interest { Id = 2, IntrestName = "Musik", Description = "Spela gitarr och lyssna på musik" },
                new Interest { Id = 3, IntrestName = "Programmering", Description = "Utveckla applikationer och hemsidor" },
                new Interest { Id = 4, IntrestName = "Resa", Description = "Besöka nya länder och kulturer" },
                new Interest { Id = 5, IntrestName = "Matlagning", Description = "Laga och njuta av god mat" },
                new Interest { Id = 6, IntrestName = "Fotografi", Description = "Ta bilder och redigera dem" },
                new Interest { Id = 7, IntrestName = "Träning", Description = "Hålla sig i form och träna" },
                new Interest { Id = 8, IntrestName = "Litteratur", Description = "Läsa böcker och skriva" },
                new Interest { Id = 9, IntrestName = "Film", Description = "Titta på filmer och serier" },
                new Interest { Id = 10, IntrestName = "Spel", Description = "Spela datorspel och brädspel" },
                new Interest { Id = 11, IntrestName = "Konst", Description = "Skapa och uppskatta konstverk" },
                new Interest { Id = 12, IntrestName = "Natur", Description = "Vandra och njuta av naturen" }
            );

            // MtmInterest
            modelBuilder.Entity<MtmInterest>().HasData(
                new MtmInterest { MtmInterestId = 1, PersonId = 1, InterestId = 1 },
                new MtmInterest { MtmInterestId = 2, PersonId = 1, InterestId = 2 },
                new MtmInterest { MtmInterestId = 3, PersonId = 2, InterestId = 3 },
                new MtmInterest { MtmInterestId = 4, PersonId = 2, InterestId = 4 },
                new MtmInterest { MtmInterestId = 5, PersonId = 3, InterestId = 5 },
                new MtmInterest { MtmInterestId = 6, PersonId = 3, InterestId = 6 },
                new MtmInterest { MtmInterestId = 7, PersonId = 4, InterestId = 2 },
                new MtmInterest { MtmInterestId = 8, PersonId = 4, InterestId = 7 },
                new MtmInterest { MtmInterestId = 9, PersonId = 5, InterestId = 8 },
                new MtmInterest { MtmInterestId = 10, PersonId = 5, InterestId = 9 },
                new MtmInterest { MtmInterestId = 11, PersonId = 6, InterestId = 10 },
                new MtmInterest { MtmInterestId = 12, PersonId = 6, InterestId = 11 },
                new MtmInterest { MtmInterestId = 13, PersonId = 7, InterestId = 12 },
                new MtmInterest { MtmInterestId = 14, PersonId = 7, InterestId = 1 },
                new MtmInterest { MtmInterestId = 15, PersonId = 8, InterestId = 3 },
                new MtmInterest { MtmInterestId = 16, PersonId = 8, InterestId = 5 }
            );

            // Links
            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, Url = "https://www.fotbollskanalen.se/", MtmInterestId = 1 },
                new Link { Id = 2, Url = "https://open.spotify.com/", MtmInterestId = 2 },
                new Link { Id = 3, Url = "https://csharpskolan.se/borja-har/", MtmInterestId = 3 },
                new Link { Id = 4, Url = "https://www.trivago.se/", MtmInterestId = 4 },
                new Link { Id = 5, Url = "https://www.kitchenlab.se/k/matlagning/", MtmInterestId = 5 },
                new Link { Id = 6, Url = "https://www.gotaplatsensfoto.se/", MtmInterestId = 6 },
                new Link { Id = 7, Url = "https://tidal.com/", MtmInterestId = 7 },
                new Link { Id = 8, Url = "https://www.actic.se/", MtmInterestId = 8 },
                new Link { Id = 9, Url = "https://litteraturbanken.se/", MtmInterestId = 9 },
                new Link { Id = 10, Url = "https://www.netflix.com/se/", MtmInterestId = 10 },
                new Link { Id = 11, Url = "https://store.steampowered.com/", MtmInterestId = 11 },
                new Link { Id = 12, Url = "https://konst.se", MtmInterestId = 12 },
                new Link { Id = 13, Url = "https://www.sverigesnatur.org/", MtmInterestId = 13 },
                new Link { Id = 14, Url = "https://allsvenskan.se/", MtmInterestId = 14 },
                new Link { Id = 15, Url = "https://www.javascript.com/", MtmInterestId = 15 },
                new Link { Id = 16, Url = "https://www.gordonramsay.com/", MtmInterestId = 16 }
            );
        }
    }
    
  
}
