namespace Sebs.Api.ErrorsManagement
{
	/// <summary>
	/// Purpose: Format the error message in case of form validation...
	/// </summary>
	public class ApiValidationErrorResponse : ApiResponse
	{
		public ApiValidationErrorResponse() 
			: base(400)
		{
		}

		public IEnumerable<string> Errors { get; set; }
	}
}
