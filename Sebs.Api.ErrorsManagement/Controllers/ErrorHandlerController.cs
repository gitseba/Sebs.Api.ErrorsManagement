using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Sebs.Api.ErrorsManagement.Controllers
{
	/// <summary>
	/// Purpose: handle requests that don't exist ({{url}}/api/endpointthatdoesnotexist)
	/// Used in conjunction with: app.UseStatusCodePagesWithReExecute("/errors/{0}");
	/// </summary>
	[Route("errors/{code}")]
	///Errors controller. Does not have an explicit binding with HTTP method.
	///And in fact, we can't even use an HTTP  here because we don't know what method is going to be used before it gets passed to this particular route.
	///So we effectively need to tell Swagger to ignore this errors controller and we can add an attribute inside here to do such a thing.
	///And we're going to say API Explorer settings and that's in parentheses and we're going to say ignore API equals true.
	///And that should resolve that particular error.
	///
	/// Basically Swagger tries to bind with the controller but the controller doesn't have HTTP methods, since it needs only to handle errors, 
	/// so explicitly say to Swagger to ignore this controller.
	[ApiExplorerSettings(IgnoreApi = true)]
	public class ErrorHandlerController : ControllerBase
	{
		public IActionResult Error(int code)
		{
			return new ObjectResult(new ApiResponse(code));
		}
	}
}