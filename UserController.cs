using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace VulnerableApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Database _db;

        public UserController(Database db)
        {
            _db = db;
        }

        [HttpGet("get-user")]
        public IActionResult GetUser(string username)
        {
            try
            {
                var result = _db.GetUserData("SELECT * FROM Users WHERE Username = '" + username + "'");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody] User user)
        {
            string sql = $"INSERT INTO Users (Username, Password) VALUES ('{user.Username}', '{user.Password}')";
            _db.ExecuteCommand(sql);
            return Ok("User created");
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
