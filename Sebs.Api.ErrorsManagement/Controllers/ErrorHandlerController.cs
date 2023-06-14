using Microsoft.AspNetCore.Mvc;

namespace Sebs.Api.ErrorsManagement.Controllers
{
	/// <summary>
	/// Used in conjunction with: app.UseStatusCodePagesWithReExecute("/errors/{0}");
	/// </summary>
	[Route("errors/{code}")]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class ErrorHandlerController : ControllerBase
	{
		public IActionResult Error(int code)
		{
			return new ObjectResult(new ApiResponse(code));
		}
	}
}