using Labb3_miniAPI.Data;
using Labb3_miniAPI.Models;
using Labb3_miniAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Labb3_miniAPI.Handlers
{
	public class InterestHandler
	{

		//Adds a new interest to an existing person
		public static IResult AddInterestToPerson(ApplicationContext context, int id, Interest interest)
		{
			Person? person = context.Persons
				.Where(p => p.Id == id)
				.Include(p => p.Interests)
				.SingleOrDefault();

			if (person == null)
			{
				return Results.NotFound("Person with that id was not found and could therefor not add any interests to");
			}

			person.Interests.Add(new Interest
			{
				InterestName = interest.InterestName,
				InterestDescription = interest.InterestDescription
			});

			context.SaveChanges();
			return Results.StatusCode((int)HttpStatusCode.Created);
		}

		//Lists interests for a specific person-id
		public static IResult ListInterestsForId(ApplicationContext context, int id)
		{
			Person? person =
				context.Persons
				.Where(p => p.Id == id)
				.Include(p => p.Interests)
				.FirstOrDefault();

			if (person == null)
			{
				return Results.NotFound("No person with that id available!");
			}


			List<InterestViewModel> result = person.Interests
				.Select(i => new InterestViewModel
				{
					InterestName = i.InterestName,
					Description = i.InterestDescription
				}).ToList();

			return Results.Json(result);
		}

	}
}
