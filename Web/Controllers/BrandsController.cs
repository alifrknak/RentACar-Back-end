using Businees.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : Controller
    {
        readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var rst = _brandService.GetAll();

			return rst.Success ? Ok(rst) : BadRequest(rst);

		}


		[HttpGet("isbrandexists")]
        public IActionResult IsBrandExists(string brandName)
        {
            var rst = _brandService.CheckByName(brandName);

            return Ok(rst);
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var rst = _brandService.Add(brand);

			return rst.Success ? Ok(rst) : BadRequest(rst);

		}

		[HttpDelete("delete")]
        public IActionResult Delete(Brand brand)
        {
            var rst = _brandService.Delete(brand);

			return rst.Success ? Ok(rst) : BadRequest(rst);

		}

		[HttpPost("update")]
        public IActionResult Update(Brand brand)
        {
            var rst = _brandService.Update(brand);
			return rst.Success ? Ok(rst) : BadRequest(rst);

		}

		[HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
            var rst = _brandService.GetByName(name);

			return rst.Success ? Ok(rst) : BadRequest(rst);

		}
	}
}
