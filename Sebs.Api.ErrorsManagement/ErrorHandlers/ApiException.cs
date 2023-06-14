namespace Sebs.Api.ErrorsManagement
{
	/// <summary>
	/// Purpose: Format the response of the API in case of exceptions 
	/// (E.g: System.NullReferenceException: Object reference not set to an instance of an object.)
	/// </summary>
	public class ApiException : ApiResponse
	{
		public ApiException(int statusCode, string message = null, string details = null)
			: base(statusCode, message)
		{
			Details = details;
		}

		public string Details { get; set; }
	}
}