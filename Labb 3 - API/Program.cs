
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

//Din första uppgift är att skapa ett grundläggande API med en databas som har följande funktioner:

//- []  Det ska gå att lagra personer med grundläggande information om dem som namn och telefonnummer
//- [ ] Systemet ska kunna lagra ett obegränsat antal intressen. Varje intresse ska ha en titel och en kort beskrivning
//- [ ] Varje person ska kunna kopplas till valfritt antal intressen
//- [ ] Det ska gå att lagra ett obegränsat antal länkar till webbplatser för varje intresse och person. En länk är alltid kopplad till både personen och intresset
//</aside>

//<aside>
//**Skapa ett REST-API**

//Det andra steget är att skapa ett REST-API som låter externa tjänster utföra följande operationer i din applikation:

//- []  Hämta alla personer i systemet
//- [ ] Hämta alla intressen kopplade till en specifik person
//- [ ] Hämta alla länkar kopplade till en specifik person
//- [ ] Koppla en person till ett nytt intresse
//- [ ] Lägga till nya länkar för en specifik person och ett specifikt intresse
//</aside>

//VG Skapa en reflektion hur jag tillämpar SOLID-principerna i min kod