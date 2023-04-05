using Businees.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}
		[HttpGet("getuserbyemail")]
		public IActionResult GetUserByemail(string email)
		{
			var rst = _userService.GetByMail(email);
			return rst.Success ? Ok(rst) : BadRequest(rst);
		}
	}
}
