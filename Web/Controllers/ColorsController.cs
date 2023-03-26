using Businees.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Color = Entities.Concrete.Color;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : Controller
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var rst = _colorService.GetAll();

			return rst.Success ? Ok(rst) : BadRequest(rst);
		}


        [HttpGet("iscolorexists")]
        public IActionResult IsColorExists(string colorName)
        {
            var rst = _colorService.CheckByName(colorName);

            return Ok(rst);
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var rst = _colorService.Add(color);

            return rst.Success ? Ok(rst) : BadRequest(rst);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Color color)
        {
            var rst = _colorService.Delete(color);

			return rst.Success ? Ok(rst) : BadRequest(rst);
		}

        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            var rst = _colorService.Update(color);

			return rst.Success ? Ok(rst) : BadRequest(rst);
		}

        [HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
            var rst = _colorService.GetByName(name);

            return rst.Success ? Ok(rst) : BadRequest(rst);
        }
    }
}