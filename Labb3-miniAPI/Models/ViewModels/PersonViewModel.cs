namespace Labb3_miniAPI.Models.ViewModels
{
	public class PersonViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int PhoneNr { get; set; }

		public ICollection<InterestViewModel> Interests { get; set; }
		public ICollection<InterestLinkViewModel> InterestLinks { get; set; }
	}
}
