using Labb3_miniAPI.Data;
using Labb3_miniAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_miniAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			string connectionString = builder.Configuration.GetConnectionString("ApplicationContext");
			builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
			var app = builder.Build();

			app.MapGet("/", () => "Hello World!");

			//POSTS

			//adds a new person to the database
			app.MapPost("/person", Person.AddPerson);

			//Adds a new interest to a person
			app.MapPost("/person/{id}/interest", Interest.AddInterestToPerson);

			//Adds a link to a specic interest and person
			app.MapPost("/person/{personId}/interest/{interestId}/interestlink", InterestLink.AddLinkToInterestAndPerson);

			//Connects an existing person with an existing interest and, if available, corresponding links. Based on ID for person and interest
			app.MapPost("/person/{personId}/interest/{interestId}", Person.AddPersonToExistingInterest);

			//GETS

			//Lists all people in the database with name and id
			app.MapGet("/person/all", Person.ListAllPeople);

			//Lists a specific person with their interests and interestlinks
			app.MapGet("/person/{id}", Person.ListSpecificPerson);

			app.Run();
		}
	}
}
