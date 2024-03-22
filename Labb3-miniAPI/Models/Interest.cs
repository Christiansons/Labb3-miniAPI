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
	}
}


