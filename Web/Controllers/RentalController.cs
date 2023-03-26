using Businees.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class RentalController : Controller
    {
        IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var rst = _rentalService.GetAll();

            return rst.Success ? Ok(rst) : BadRequest(rst);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int brandid)
        {
            var rst = _rentalService.GetById(brandid);

			return rst.Success ? Ok(rst) : BadRequest(rst);

		}

		[HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var rst = _rentalService.Add(rental);

            return rst.Success ? Ok(rst) : BadRequest(rst);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Rental rental)
        {
            var rst = _rentalService.Delete(rental);

            return rst.Success ? Ok(rst) : BadRequest(rst);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var rst = _rentalService.Update(rental);

            return rst.Success ? Ok(rst) : BadRequest(rst);
        }

        [HttpGet("bybrand")]
        public IActionResult GetByBrand(int id)
        {
            var rst = _rentalService.GetById(id);

            return rst.Success ? Ok(rst) : BadRequest(rst);
        }

        [HttpGet("isrental")]
        public IActionResult IsCarRental(int carId)
        {
            var rst = _rentalService.IsCarRental(carId);

            return Ok(rst);

        }

	}
}
