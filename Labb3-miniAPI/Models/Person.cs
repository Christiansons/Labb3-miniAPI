using Labb3_miniAPI.Data;
using Labb3_miniAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json.Serialization;

namespace Labb3_miniAPI.Models
{
	public class Person
	{
		public int Id { get; set; }
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("phoneNr")]
		public int PhoneNr { get; set; }

		public virtual ICollection<Interest> Interests { get; set; }
		public virtual ICollection<InterestLink> InterestLinks { get; set; }

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

		//List specific person
		public static IResult ListSpecificPerson(ApplicationContext context, int id)
		{
			//Checks for a specific person based on ID
			Person? person = 
				context.Persons
				.Where(p => p.Id == id)
				.Include(p => p.Interests)
				.Include (p => p.InterestLinks)
				.FirstOrDefault();

			if(person == null)
			{
				return Results.NotFound("No person with that id available!");
			}

			//Create a ViewModel for the person with all information including interests and links
			PersonViewModel result = new PersonViewModel()
			{
				Id = person.Id,
				Name = person.Name,
				PhoneNr = person.PhoneNr,
				Interests = person.Interests
				.Select(I => new InterestViewModel
				{
					Name = I.InterestName,
					Description = I.InterestDescription,
				}).ToList(),
				InterestLinks = person.InterestLinks
				.Select(IL => new InterestLinkViewModel
				{
					Url = IL.Url
				}).ToList()
			};
				
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

		//Connect existing person to interest
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
