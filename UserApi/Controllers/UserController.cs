using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            using (var context = new UserDbContext())
            {
                return StatusCode(201, context.NewUsers.ToList());
            }
        }
        
        [HttpPost]
        public ActionResult<User> Post()
        {
            using (var context = new UserDbContext())
            {
                return Ok();
            }
        }
    }
}
