using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using PersonDetails_WEBAPI_Test.Controllers;
using PersonDetails_WEBAPI_Test.Model;
using PersonDetails_WEBAPI_Test.Services;


namespace PersonDetails_WEBAPI_Test.Tests
{
	public class PersondetailsControllerTests
	{
		private readonly Mock<IPersonService> personService;
		private readonly Mock<ILogger<PersondetailsController>> loggerMock;
		private readonly PersondetailsController _sut;

		public PersondetailsControllerTests()
		{
			personService = new Mock<IPersonService>();
			loggerMock = new Mock<ILogger<PersondetailsController>>();
			_sut = new PersondetailsController(personService.Object, loggerMock.Object);
		}

		[Fact]
		public void GetAllPersonsList_GetAllList_returnPersonsdataList()
		{
			//arrange
			var personsList = GetPersonsData();
			personService.Setup(x => x.GetAllList())
				.ReturnsAsync(personsList);
			var personsController = new PersondetailsController(personService.Object, loggerMock.Object);

			//act
			var personsResult = personsController.GetAllList().Result;

			//assert
			Assert.NotNull(personsResult);
			Assert.Equal(GetPersonsData().Count(), personsResult.Count());
			Assert.Equal(GetPersonsData().ToString(), personsResult.ToString());
			Assert.True(personsList.Equals(personsResult));
		}


		[Fact]
		public async Task AddPersonDetails_AddPerson_returnOkOnPost()
		{
			// Arrange
			var personsList = GetPersonsData();
			personService.Setup(x => x.AddPerson(personsList[0]))
				.ReturnsAsync(personsList);

			var personsController = new PersondetailsController(personService.Object, loggerMock.Object);

			// Act
			var personsResult = await personsController.AddPerson(personsList[0]);
			var expectedLocationName = personsResult.ToList()[0].Name;

			// Assert
			Assert.NotNull(personsResult);
			Assert.Equal(personsList[0].Name, expectedLocationName);
		}

		[Theory]
		[InlineData("New York")]
		public async Task CheckPersonExistOrNotByLocation_GetPersonByLocation_PersonsList(string location)
		{
			// Arrange
			var personsList = GetPersonsData();
			personService.Setup(x => x.GetPersonByLocation(location))
				.ReturnsAsync(personsList);
			var personsController = new PersondetailsController(personService.Object, loggerMock.Object);

			// Act
			var personsResult = await personsController.GetPersonByLocation(location);
			var expectedLocationName = personsResult.ToList()[0].CurrentLocation;

			// Assert
			Assert.Equal(location, expectedLocationName);
			Assert.Equal(2, personsResult.Count());
			Assert.Contains(personsResult, p => p.Name == "John Doe");
			Assert.Contains(personsResult, p => p.Name == "Jane Smith");
		}


		[Theory]
		[InlineData("C#")]
		public async Task CheckPersonExistOrNotBytechnology_GetPersonByTechnology_PersonsList(string technology)
		{
			// Arrange
			var personsList = GetPersonsData();
			personService.Setup(x => x.GetPersonByTechnology(technology))
				.ReturnsAsync(personsList);
			var personsController = new PersondetailsController(personService.Object, loggerMock.Object);

			// Act
			var personsResult = await personsController.GetPersonByTechnology(technology);
			var expectedTechName = personsResult.ToList()[0].TechnicalExperiences![0].TechnologyName;
			var expectedtechName1 = personsResult.ToList()[1].TechnicalExperiences![0].TechnologyName;
			var expectedLocationName = personsResult.ToList()[0].CurrentLocation;

			// Assert
			Assert.Equal(technology, expectedTechName);
			Assert.Equal(technology, expectedTechName);
			Assert.Equal(2, personsResult.Count());
			Assert.Contains(personsResult, p => p.Name == "John Doe");
			Assert.Contains(personsResult, p => p.Name == "Jane Smith");
			
		}

		[Theory]
		[InlineData("New York", "C#")]
		public async Task CheckPersonExistOrNot_GetPersonByTechnologyAndLocation_PersonsList(string location, string technology)
		{
			// Arrange
			var personsList = GetPersonsData(); // Assuming you have a method to get sample persons data
			personService.Setup(x => x.GetPersonByTechnologyandlocation(location, technology))
				.ReturnsAsync(personsList);
			var personsController = new PersondetailsController(personService.Object, loggerMock.Object);

			// Act
			var personsResult = await personsController.GetPersonByTechnologyandlocation(location, technology);
			var expectedTechName = personsResult.ToList()[0].TechnicalExperiences![0].TechnologyName;
			var expectedLocationName = personsResult.ToList()[0].CurrentLocation;

			// Assert
			Assert.Equal(technology, expectedTechName);
			Assert.Equal(location, expectedLocationName);
			Assert.NotNull(personsResult);
			Assert.Equal(2, personsResult.Count());
			Assert.Contains(personsResult, p => p.Name == "John Doe");
			Assert.Contains(personsResult, p => p.Name == "Jane Smith");
		}


		private List<PersonDetails> GetPersonsData()
		{

			var persons = new List<PersonDetails>
		{
				new PersonDetails
				{
					Name = "John Doe",
					Gender = true,
					DateOfBirth = new DateTime(1990, 1, 1),
					EmailId = "john@example.com",
					CurrentLocation = "New York",
					TechnicalExperiences = new List<TechnicalExperience>
					{
						new TechnicalExperience
						{
							TechnologyName = "C#",
							CompanyName = "ABC Corp",
							WorkedFrom = new DateTime(2018, 1, 1),
							WorkedTo = new DateTime(2020, 12, 31)
						},
						new TechnicalExperience
						{
							TechnologyName = "Java",
							CompanyName = "XYZ Inc",
							WorkedFrom = new DateTime(2015, 1, 1),
							WorkedTo = new DateTime(2017, 12, 31)
						}
					}
				},
				new PersonDetails
				{
					Name = "Jane Smith",
					Gender = false,
					DateOfBirth = new DateTime(1992, 5, 10),
					EmailId = "jane@example.com",
					CurrentLocation = "New York",
					TechnicalExperiences = new List<TechnicalExperience>
					{
						new TechnicalExperience
						{
							TechnologyName = "C#",
							CompanyName = "DEF Corp",
							WorkedFrom = new DateTime(2020, 1, 1),
							WorkedTo = new DateTime(2022, 12, 31)
						},
						new TechnicalExperience
						{
							TechnologyName = "Python",
							CompanyName = "PQR Ltd",
							WorkedFrom = new DateTime(2019, 1, 1),
							WorkedTo = new DateTime(2020, 12, 31)
						}
					}
				},

			};
			return persons;


		}
	}
}