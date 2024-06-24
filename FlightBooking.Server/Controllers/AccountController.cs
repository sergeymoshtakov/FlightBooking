using FlightBooking.Server.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FlightBooking.Server.Data;
using FlightBooking.Server.Services;

namespace FlightBooking.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserSessionService _userSessionService;
        private readonly ILogger<AccountController> _logger; 

        public AccountController(ApplicationDbContext context, IUserSessionService userSessionService, ILogger<AccountController> logger)
        {
            _context = context;
            _userSessionService = userSessionService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.Users.Any(u => u.Email == user.Email))
            {
                return BadRequest("User with this email already exists.");
            }

            user.UserId = Guid.NewGuid();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == loginModel.Email && u.Password == loginModel.Password);

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            var session = new UserSession { UserId = user.UserId, IsAuthenticated = true };
            _userSessionService.SetUserSession(session);

            // Устанавливаем куку с UserId
            Response.Cookies.Append("userId", user.UserId.ToString(), new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None, // Настройте по необходимости
                Secure = true // Настройте по необходимости
            });

            return Ok();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            if (HttpContext.Request.Cookies.ContainsKey("userId"))
            {
                var userId = Guid.Parse(HttpContext.Request.Cookies["userId"]);
                _userSessionService.ClearUserSession(userId);

                // Удаляем куку
                Response.Cookies.Delete("userId");
            }

            return Ok();
        }

        [HttpGet("isAuthenticated")]
        public IActionResult IsAuthenticated()
        {
            try
            {
                var userId = Guid.Parse(HttpContext.Request.Cookies["userId"]);
                var session = _userSessionService.GetUserSession(userId);

                if (session != null && session.IsAuthenticated)
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in IsAuthenticated: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
