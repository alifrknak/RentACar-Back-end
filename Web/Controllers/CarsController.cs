using Businees.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;


namespace Web.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
           
        }
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var rst = _carService.GetAll();
           
            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int carid)
        {
            var rst = _carService.GetById(carid);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpPost("add")]
        public IActionResult Add(Entities.Concrete.Car car)
        {
            var rst = _carService.Add(car);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Entities.Concrete.Car car)
        {
            var rst = _carService.Delete(car);

            if (rst.Success)
            {
                return Ok(rst);
            }
            
            return BadRequest(rst);
        }

        [HttpPost("update")]
        public IActionResult Update(Entities.Concrete.Car car)
        {
            var rst = _carService.Update(car);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpGet("bybrand")]
        public IActionResult GetByBrand(int id)
        {
            var rst = _carService.GetByBrand(id);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpGet("detail")]
        public IActionResult GetCarDetails(Entities.Concrete.Car car)
        {
            var rst = _carService.GetCarDetails();

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }
    }
}