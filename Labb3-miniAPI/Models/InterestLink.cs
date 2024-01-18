using Labb3_miniAPI.Data;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Text.Json.Serialization;

namespace Labb3_miniAPI.Models
{
	public class InterestLink
	{
		public int Id { get; set; }
		[JsonPropertyName("url")]
		public string Url { get; set; }
		public virtual Interest Interest { get; set; }
		public virtual Person Person { get; set; }

		public static IResult AddLinkToInterestAndPerson(ApplicationContext context, int personId, int interestId, InterestLink newLink)
		{
			Person? person = context.Persons
				.Where(p => p.Id == personId)
				.Include(p => p.InterestLinks)
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
	}
}
