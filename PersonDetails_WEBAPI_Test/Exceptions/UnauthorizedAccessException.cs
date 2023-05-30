namespace PersonDetails_WEBAPI_Test.Exceptions
{
	public class UnauthorizedAccessException : Exception
	{
		public UnauthorizedAccessException(string message) : base(message) { }
	}
}