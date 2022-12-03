using Businees.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        protected IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var rst = _userService.GetAll();

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int brandid)
        {
            var rst = _userService.GetById(brandid);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var rst = _userService.Add(user);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(User user)
        {
            var rst = _userService.Delete(user);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var rst = _userService.Update(user);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpGet("bybrand")]
        public IActionResult GetByBrand(int id)
        {
            var rst = _userService.GetById(id);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }
    }
}
