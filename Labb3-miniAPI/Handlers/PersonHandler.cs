using Labb3_miniAPI.Data;
using Labb3_miniAPI.Models.ViewModels;
using Labb3_miniAPI.Models;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace Labb3_miniAPI.Handlers
{
	public class PersonHandler
	{
		//List all people
		public static IResult ListAllPeople(ApplicationContext context)
		{
			ListPersonsViewModel[] result = context.Persons
				.Select(p => new ListPersonsViewModel
				{
					Id = p.Id,
					Name = p.Name,
				}).ToArray();

			return Results.Json(result);
		}

		//Creates a new person
		public static IResult AddPerson(ApplicationContext context, Person person)
		{
			context.Persons.Add(new Person
			{
				Name = person.Name,
				PhoneNr = person.PhoneNr
			});

			context.SaveChanges();
			return Results.StatusCode((int)HttpStatusCode.Created);
		}

		//Connect existing person to existing interest
		public static IResult AddPersonToExistingInterest(ApplicationContext context, int personId, int interestId)
		{
			Person? person = context.Persons
				.Where(p => p.Id == personId)
				.Include(p => p.Interests)
				.FirstOrDefault();

			Interest? interest = context.Interests
				.Where(i => i.Id == interestId)
				.FirstOrDefault();

			if (person == null || interest == null)
			{
				return Results.NotFound(new { failMessage = "No person with that id available!" });
			}

			person.Interests.Add(interest);
			context.SaveChanges();
			return Results.StatusCode((int)HttpStatusCode.Created);
		}
	}
}
