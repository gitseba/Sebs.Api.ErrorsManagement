using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sebs.Api.ErrorsManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ErrorGeneratorController : ControllerBase
	{

		[HttpGet("auth")]
		[Authorize]
		public ActionResult<string> GetSecretText()
		{
			return "secrets protected by auth guardians.";
		}

		[HttpGet("notfound")]
		public ActionResult GetNotFoundRequest()
		{
			object someObj = null;

			if (someObj == null) return NotFound(new ApiResponse(404));

			return Ok();
		}

		[HttpGet("servererror")]
		public ActionResult GetServerError()
		{
			object someObj = null;

			var thingToReturn = someObj.ToString();

			return Ok();
		}

		[HttpGet("badrequest")]
		public ActionResult GetBadRequest()
		{
			return BadRequest(new ApiResponse(400));
		}

		[HttpGet("badrequest/{id}")]
		public ActionResult GetNotFoundRequest(int id)
		{
			return Ok();
		}
	}
}