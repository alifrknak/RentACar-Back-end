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

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int brandid)
        {
            var rst = _colorService.GetById(brandid);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var rst = _colorService.Add(color);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Color color)
        {
            var rst = _colorService.Delete(color);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            var rst = _colorService.Update(color);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpGet("bybrand")]
        public IActionResult GetByBrand(int id)
        {
            var rst = _colorService.GetById(id);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }
    }
}