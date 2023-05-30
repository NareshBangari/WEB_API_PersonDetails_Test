namespace PersonDetails_WEBAPI_Test.Exceptions
{
	public class BadRequestException : Exception
	{
		public BadRequestException(string message) : base(message) { }
	}
}