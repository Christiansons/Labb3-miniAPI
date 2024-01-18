using Labb3_miniAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Net;
using System.Text.Json.Serialization;

namespace Labb3_miniAPI.Models
{
	public class Interest
	{
		public int Id { get; set; }
		[JsonPropertyName("interestName")]
		public string InterestName { get; set; }
		[JsonPropertyName("interestDescription")]
		public string InterestDescription { get; set; }

		public virtual ICollection<Person> Persons { get; set; }
		public virtual ICollection<InterestLink> InterestLinks { get; set; }

		
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
	}
}


