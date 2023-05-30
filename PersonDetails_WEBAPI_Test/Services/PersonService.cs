using PersonDetails_WEBAPI_Test.Data;
using PersonDetails_WEBAPI_Test.Model;
using PersonDetails_WEBAPI_Test.Controllers;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace PersonDetails_WEBAPI_Test.Services
{
	public class PersonService : IPersonService
	{

		private readonly DbContextClass _dbContext;
		public PersonService(DbContextClass dbContext)
		{
			_dbContext = dbContext;
		}
		
		public async Task<IEnumerable<PersonDetails>> GetAllList()
		{
			return await _dbContext.PersonDetalisTest.Include(c => c.TechnicalExperiences).ToListAsync();
		}
		public async Task<IEnumerable<PersonDetails>> AddPerson(PersonDetails person)
		{
			var result = _dbContext.PersonDetalisTest.Add(person);
			await _dbContext.SaveChangesAsync();
			return new List<PersonDetails> {person };

		}

		private PersonDetails Ok(EntityEntry<PersonDetails> result)
		{
			throw new NotImplementedException();
		}


		public  async Task<IEnumerable<PersonDetails>> GetPersonByTechnology(string technologyname)
		{
			IQueryable<PersonDetails> query = _dbContext.PersonDetalisTest;

			query = query.Where(p => p.TechnicalExperiences!.Any(t => t.TechnologyName == technologyname)).Include(c => c.TechnicalExperiences);
			return await query.ToListAsync();
			

		}


		

		public async Task<IEnumerable<PersonDetails>> GetPersonByLocation(string location)
		{
			IQueryable<PersonDetails> query = _dbContext.PersonDetalisTest.Include(c => c.TechnicalExperiences);

			query = query.Where(p => p.CurrentLocation == location).Include(c => c.TechnicalExperiences);
			
			return await query.ToListAsync();
			

		}


		public async Task<IEnumerable<PersonDetails>> GetPersonByTechnologyandlocation(string location, string technology)
		{
			IQueryable<PersonDetails> query = _dbContext.PersonDetalisTest.Include(c => c.TechnicalExperiences);
				
				query = query.Where(p => p.CurrentLocation == location && p.TechnicalExperiences!.Any(t => t.TechnologyName == technology)).Include(c => c.TechnicalExperiences);
				
				return await query.ToListAsync();
				
			

		}





	}


}

		









	



