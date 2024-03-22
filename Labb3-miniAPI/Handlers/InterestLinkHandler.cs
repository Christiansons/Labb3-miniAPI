using Labb3_miniAPI.Data;
using Labb3_miniAPI.Models;
using Labb3_miniAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Labb3_miniAPI.Handlers
{
	public class InterestLinkHandler
	{
		//Adds a new link to an interest and person
		public static IResult AddLinkToInterestAndPerson(ApplicationContext context, int personId, int interestId, InterestLink newLink)
		{
			Person? person = context.Persons
				.Where(p => p.Id == personId)
				.Include(p => p.Interests)
				.SingleOrDefault();

			Interest? interest = context.Interests
				.Where(i => i.Id == interestId)
				.Include(p => p.InterestLinks)
				.SingleOrDefault();

			if (person == null || interest == null)
			{
				return Results.NotFound("Person or interest with that id was not found and could therefor not add any links to");
			}

			context.InterestLinks
				.Add(new InterestLink
				{
					Url = newLink.Url,
					Person = person,
					Interest = interest
				});

			context.SaveChanges();
			return Results.StatusCode((int)HttpStatusCode.Created);
		}

		//Lists all interestlinks for a specific person-id
		public static IResult ListInterestLinksForId(ApplicationContext context, int id)
		{
			Person? person =
				context.Persons
				.Where(p => p.Id == id)
				.Include(p => p.InterestLinks)
				.FirstOrDefault();

			if (person == null)
			{
				return Results.NotFound("No person with that id available!");
			}


			List<InterestLinkViewModel> result = person.InterestLinks
				.Select(l => new InterestLinkViewModel
				{
					Url = l.Url
				}).ToList();

			return Results.Json(result);
		}
	}
}
