using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

       [HttpGet]
        public string Get()
        {
            return "Hello from product controller";
        }

        [HttpGet("GetEmployeeName")]
        public string[] GetData()
        {
            string[] name = { "John", "Doe", "Jane" };
            return name;
        }

        [HttpGet("GetDataValue")]
        public IActionResult GetDataValue()
        {
            List<string> names = new List<string>();
            names.Add("John");
            names.Add("Doe");
            return Ok(names);
        }

        [HttpGet("Getnames")]
        public IActionResult Getnames()
        {
            List<string> names = new List<string>();
            names.Add("john");
            names.Add("Doe");
            return new JsonResult(names);
        }

        [HttpGet("GetDatafromSAP")]
        public IActionResult GetDatafromSAP()
        {
            List<string> names = new List<string>();
            names.Add("john");
            names.Add("Doe");
            return new StatusCodeResult(StatusCodes.Status426UpgradeRequired);

        }

        [HttpGet("UnGetDatafromSAP")]
        public IActionResult UnGetDatafromSAP()
        {
            List<string> names = new List<string>();
            names.Add("john");
            names.Add("Doe");
            return new UnauthorizedResult();

        }

        [HttpGet("BadRequestResult")]

        public IActionResult BadRequestResult()
        {
            List<string> names = new List<string>();
            names.Add("john");
            names.Add("Doe");
            return new BadRequestResult();
        }

        [HttpGet("NotFoundResult")]
        public IActionResult NotFoundResult()
        {
            List<string> names = new List<string>();
            names.Add("john");
            names.Add("Doe");
            return new NotFoundResult();

        }

        [HttpPost("Register")]
        public IActionResult RegisterEmployee(string name)
        {
            return Ok("Employee Registered Successfully");
        }

        [HttpPost("UpdateEmployee/{name}")]
        public IActionResult updateEmployee(string name)
        {
            return Ok("Employee Registered Successfully");
        }


        [HttpPost("RegisterForm")]
        public IActionResult RegisterForm([FromForm] Product productdetails)
        {
            return Ok(productdetails.Price.ToString());
        }


        [HttpPost("RegisterFormHeader")]
        public IActionResult RegisterForm([FromForm] Product productdetails, [FromHeader] string useragent)
        {
            if (useragent == "JS")
            {
                return Ok(productdetails.Price.ToString());
            }
            else
            {
                return new UnauthorizedResult();
            }
        }




    }

    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
