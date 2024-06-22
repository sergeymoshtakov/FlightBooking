using FlightBooking.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        static readonly List<User> data;
        static UsersController()
        {
            data = new List<User>
            {
                new User {
                    UserId = Guid.NewGuid(), 
                    Name = "John Doe",
                    Email = "hahaha@example.com",
                    Password = "password1",
                    Phone = "1234567890",
                },
                new User {
                    UserId = Guid.NewGuid(), 
                    Name = "John Smith",
                    Email = "lalala@example.com",
                    Password = "password2",
                    Phone = "1234567890",
                },
            };
        }

        [HttpGet(Name = "GetUsers")]
        public IEnumerable<User> Get()
        {
            return data;
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            user.UserId = Guid.NewGuid();
            data.Add(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            User user = data.FirstOrDefault(x => x.UserId == new Guid(id));
            if (user == null)
            {
                return NotFound();
            }
            data.Remove(user);
            return Ok(user);
        }
    }
}