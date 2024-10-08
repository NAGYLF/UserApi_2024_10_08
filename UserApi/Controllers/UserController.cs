using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;
using static UserApi.Models.Dto;

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
        public ActionResult<User> Post(CreateUserDto createUserDto)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = createUserDto.Name,
                Age = createUserDto.Age,
                License = createUserDto.License,
            };
            using (var context = new UserDbContext())
            {
                context.NewUsers.Add(user);
                context.SaveChanges();
                return StatusCode(201, user);
            }
        }
        [HttpPut("{User_Update}")]
        public ActionResult<User> Put(Guid User_Update,UpdateUserDto updateUserDto)
        {
            using (var conext = new UserDbContext())
            {
                var existingUser = conext.NewUsers.FirstOrDefault(x => x.Id == User_Update);

                existingUser.Name = updateUserDto.Name;
                existingUser.Age = updateUserDto.Age;
                existingUser.License = updateUserDto.License;

                conext.NewUsers.Update(existingUser);
                conext.SaveChanges();
                return StatusCode(200,existingUser);
            }
        }
        [HttpDelete("{User_Delete}")]
        public ActionResult<object> Delete(Guid User_Delete)
        {
            using (var conext = new UserDbContext())
            {
                var existingUser = conext.NewUsers.FirstOrDefault(x => x.Id == User_Delete);
                conext.NewUsers.Remove(existingUser);
                conext.SaveChanges();
                return StatusCode(200,new {message = "Sikeres törles" });
            }
        }

        [HttpGet("{UserFindById}")]
        public ActionResult<User> GetById(Guid UserFindById)
        {
            using (var conext = new UserDbContext())
            {   
                return StatusCode(200, conext.NewUsers.FirstOrDefault(x => x.Id == UserFindById));
            }
        }
    }
}
