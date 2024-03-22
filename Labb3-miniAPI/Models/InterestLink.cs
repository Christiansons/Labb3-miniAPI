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
	}
}
