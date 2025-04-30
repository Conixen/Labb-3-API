
using Labb_3___API.Services;

namespace Labb_3___API
{
    public class Program
    {
        public static void Main(string[] args)

        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<LaPerosnaService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

//**Applikationen / databasen * *

//Din f�rsta uppgift �r att skapa ett grundl�ggande API med en databas som har f�ljande funktioner:

//- []  Det ska g� att lagra personer med grundl�ggande information om dem som namn och telefonnummer
//- [ ] Systemet ska kunna lagra ett obegr�nsat antal intressen. Varje intresse ska ha en titel och en kort beskrivning
//- [ ] Varje person ska kunna kopplas till valfritt antal intressen
//- [ ] Det ska g� att lagra ett obegr�nsat antal l�nkar till webbplatser f�r varje intresse och person. En l�nk �r alltid kopplad till b�de personen och intresset
//</aside>

//<aside>
//**Skapa ett REST-API**

//Det andra steget �r att skapa ett REST-API som l�ter externa tj�nster utf�ra f�ljande operationer i din applikation:

//- []  H�mta alla personer i systemet
//- [ ] H�mta alla intressen kopplade till en specifik person
//- [ ] H�mta alla l�nkar kopplade till en specifik person
//- [ ] Koppla en person till ett nytt intresse
//- [ ] L�gga till nya l�nkar f�r en specifik person och ett specifikt intresse
//</aside>

//VG Skapa en reflektion hur jag till�mpar SOLID-principerna i min kod