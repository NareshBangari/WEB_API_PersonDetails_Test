using PersonDetails_WEBAPI_Test.Exceptions;
using PersonDetails_WEBAPI_Test.Model;
using PersonDetails_WEBAPI_Test.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using NotImplementedException = PersonDetails_WEBAPI_Test.Exceptions.NotImplementedException;
using System;
using Microsoft.EntityFrameworkCore;

namespace PersonDetails_WEBAPI_Test.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersondetailsController : ControllerBase
	{
		private readonly IPersonService personService;
		private ILogger<PersondetailsController> _logger;

		public PersondetailsController(IPersonService _personService, ILogger<PersondetailsController> logger)
		{
			personService = _personService;
			_logger = logger;
		}

		

		[HttpGet("PersonDetailsList")]
		public async Task<IEnumerable<PersonDetails>> GetAllList()
		{
			var personDetailsList = personService.GetAllList();
			if (!personDetailsList.Result.Any())
			{
				throw new NotFoundException($"PersonDetails List is empty.");
			}
			return await personDetailsList;
		}

		
		[HttpPost("Add_Person")]
		public async Task<IEnumerable<PersonDetails>> AddPerson(PersonDetails person)
		{
			return await personService.AddPerson(person);
			
		}

		[HttpGet("Get_Person_By_Tech")]
		public async Task<IEnumerable<PersonDetails>> GetPersonByTechnology(string technologyname)
		{
			
			_logger.LogInformation( $"Fetch Person with TechnologyName:"+ " "+ technologyname+ "from the database");
			var details = personService.GetPersonByTechnology(technologyname);
			if (!details.Result.Any())
			{
				throw new NotFoundException( $"PersonDetails with given TechnologyName:"+" "+ technologyname +" is not found.");
			}
			_logger.LogInformation($"Returning person with tencnologyname:"+" "+ technologyname);

			return await details;
		}

		[HttpGet("Get_Person_By_Location")]
		public async Task<IEnumerable<PersonDetails>> GetPersonByLocation(string? location)
		{
			_logger.LogInformation( $"Fetch Person Details with given location:" +""+location+ "from the database");
			var details = personService.GetPersonByLocation(location!);
			if (!details.Result.Any())
			{
				throw new NotFoundException( $"PersonDetails with given location:" +" "+location +" is not found.");
			}
			_logger.LogInformation($"Returning person with location:"+" "+ location);

			return await details;
		}

		[HttpGet("Get_Person_By_Technology_and_Location")]
		public async Task<IEnumerable<PersonDetails>> GetPersonByTechnologyandlocation(string location, string technology)
		{

			_logger.LogInformation($"Fetch person with technologyname and Location from the database");
			var details = personService.GetPersonByTechnologyandlocation(location, technology);
			if (!details.Result.Any())
			{
				throw new NotFoundException($"PersonDetails with given"+" "+ technology+" " +"and"+ " "+location + " "+"are not found.");
			}
			_logger.LogInformation($"Returning person with tencnologyname: {details.Result}.");

			return await details;
		}

		


	}
}