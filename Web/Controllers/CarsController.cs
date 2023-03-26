using Businees.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		ICarService _carService;

		public CarsController(ICarService carService)
		{
			_carService = carService;
		}

		[HttpPost("add")]
		public IActionResult Add(Car car)
		{
			var rst = _carService.Add(car);

			return rst.Success ? Ok(rst) : BadRequest(rst);

		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var rst = _carService.GetAll();

			return rst.Success ? Ok(rst) : BadRequest(rst);
		}

		[HttpGet("getbybrand")]
		public IActionResult GetByBrand(int brandId)
		{
			var rst = _carService.GetByBrand(brandId);

			return rst.Success ? Ok(rst) : BadRequest(rst);

		}

		[HttpGet("getbycolor")]
		public IActionResult GetByColor(int colorId)
		{
			var rst = _carService.GetByColor(colorId);
			
			return rst.Success ? Ok(rst) : BadRequest(rst);

		}

		[HttpGet("getcardetailsbyid")]
		public IActionResult GetCarDetails(int carId) 
		{
			var  rst = _carService.GetCarDetails(carId);
			
			return rst.Success ? Ok(rst) : BadRequest(rst);
		}
	}
}