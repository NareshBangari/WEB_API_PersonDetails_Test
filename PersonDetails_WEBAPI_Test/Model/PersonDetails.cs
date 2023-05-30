using System.ComponentModel.DataAnnotations;

namespace PersonDetails_WEBAPI_Test.Model
{
	public class PersonDetails
	{
			

			public string? Name { get; set; }
			public bool Gender { get; set; }
			public DateTime DateOfBirth { get; set; }
			[Key]
			public string? EmailId { get; set; }
			public string? CurrentLocation { get; set; }
			public List<TechnicalExperience>? TechnicalExperiences { get; set; }
		

	}


	public class TechnicalExperience
	{

		public string? TechnologyName { get; set; }

		[Key]
		public string? CompanyName { get; set; }
		public DateTime WorkedFrom { get; set; }
		public DateTime WorkedTo { get; set; }
	}
}
