using Businees.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : Controller
    {
        readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var rst = _carImageService.GetAll();

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }
        public IActionResult GetById(int id)
        {
            var rst = _carImageService.GetById(id);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }
        public IActionResult GetImagesByCarId(int id)
        {
            var rst = _carImageService.GetImagesByCarId(id);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }
        [HttpPost("add")]
        public IActionResult Add(CarImage carImage)
        {
            var rst = _carImageService.Add(carImage);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }
        public IActionResult Delete(CarImage carImage)
        {
            var rst = _carImageService.Delete(carImage);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }
        public IActionResult Update(CarImage carImage)
        {
            var rst = _carImageService.Update(carImage);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

    }
}
