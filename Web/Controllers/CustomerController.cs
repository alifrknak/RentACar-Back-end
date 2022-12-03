using Businees.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var rst = _customerService.GetAll();

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int brandid)
        {
            var rst = _customerService.GetById(brandid);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var rst = _customerService.Add(customer);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Customer customer)
        {
            var rst = _customerService.Delete(customer);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var rst = _customerService.Update(customer);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }

        [HttpGet("bybrand")]
        public IActionResult GetByBrand(int id)
        {
            var rst = _customerService.GetById(id);

            if (rst.Success)
            {
                return Ok(rst);
            }
            return BadRequest(rst);
        }
    }
}
