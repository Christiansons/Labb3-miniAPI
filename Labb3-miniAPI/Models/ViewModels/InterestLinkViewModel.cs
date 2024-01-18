using System.Text.Json.Serialization;

namespace Labb3_miniAPI.Models.ViewModels
{
	public class InterestLinkViewModel
	{
		[JsonPropertyName ("url")]
		public string Url { get; set; }
	}
}
