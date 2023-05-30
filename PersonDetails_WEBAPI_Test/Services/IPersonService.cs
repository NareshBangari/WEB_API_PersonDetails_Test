using PersonDetails_WEBAPI_Test.Model;

namespace PersonDetails_WEBAPI_Test.Services
{
		
		public interface IPersonService
		{
			public  Task<IEnumerable<PersonDetails>> GetAllList();
			public Task<IEnumerable<PersonDetails>> AddPerson(PersonDetails person);
			public Task<IEnumerable<PersonDetails>> GetPersonByLocation(string location);
			public Task<IEnumerable<PersonDetails>> GetPersonByTechnology(string technologyname);

			public Task<IEnumerable<PersonDetails>> GetPersonByTechnologyandlocation(string location, string technology);

			


		}

}

