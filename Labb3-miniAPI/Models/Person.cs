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
	}
}
