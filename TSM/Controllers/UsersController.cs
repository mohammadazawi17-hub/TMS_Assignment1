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


        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int userId)
        {
            var user = _dbContext.Users.Find(userId);

            if (user == null)
                return NotFound("User not found");

            var result = new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserName = user.UserName
            };

            return Ok(result);
        }


        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UpdateUserDto dto)
        {
            var user = _dbContext.Users.Find(dto.Id);
            if (user == null)
                return NotFound("User not found");

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.UserName = dto.UserName;
            user.Password = dto.Password;

            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost("GetUserListWithSearch")]
        public IActionResult GetUserListWithSearch([FromBody] UserListSearchDto dto)
        {
            var query = _dbContext.Users.AsQueryable();

            
            if (!string.IsNullOrWhiteSpace(dto.SearchText))
            {
                query = query.Where(u => u.Name.Contains(dto.SearchText));
            }

            var users = query
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    UserName = u.UserName
                })
                .ToList();

            return Ok(users);
        }
    }
}
