using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.BusinessLogic;
using ShopAPI.Model;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserLogic _userLogic;

        public UserController(UserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpPost("Register")]

        public IActionResult Register([FromBody] StudentReg studentReg)
        {
            if(studentReg == null)
            {
                return BadRequest("student is null.");
            }

            int val = _userLogic.Registration(studentReg);
            if (val > 0)
            
            {
                return Ok("student Registered Successfully");

            }
            else
            {
                return BadRequest("student Registered failed");

            }
        }

        [HttpPost("Login")]

        public IActionResult Login([FromBody] StudentReg studentReg)
        {
            if(studentReg == null)
            {
                return BadRequest("student is null.");
            }

            int val = _userLogic.Registration(studentReg);
            if (val != null)

            {
                return Ok(val.ToString());
            }
            else
            {
                return BadRequest("Login Failed");
            }
        }
    }
}
