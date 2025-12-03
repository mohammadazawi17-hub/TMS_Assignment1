using Application.DTOs;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace TMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private TMSDbContext _dbContext;
        public UsersController(TMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] CreateUserDto user)
        {
            var userObj = new User();

            userObj.Name = user.Name;
            userObj.Email = user.Email;
            userObj.UserName = user.UserName;
            userObj.Password = user.Password;

            _dbContext.Users.Add(userObj);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int userid)
        {

            var userObjToDelete = _dbContext.Users.Find(userid);
            _dbContext.Users.Remove(userObjToDelete);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}
