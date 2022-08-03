using LoanApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LoanContext _context;
        public UserController(LoanContext loanDbContext)
        {
            _context = loanDbContext;

        }

        [HttpGet("getAllUsers")]
        public IActionResult getAllUsers()
        {
           var usersList =_context.User.AsQueryable();
            return Ok(usersList);
        }

        [HttpPost("userLogin")]
        public IActionResult userLogin(User userinfo) {

            var user = _context.User.Where(d => d.Username == userinfo.Username && d.Password == userinfo.Password).FirstOrDefault();

            if (user != null)
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Login Suceessfully",
                    User=user
                });
            }
            else
            {
                return Ok("User not found");
            }
        }
    }
}
