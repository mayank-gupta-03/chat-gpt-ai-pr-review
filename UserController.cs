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

        void ConnectionCreation(){
Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
 
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
 
            string connString = "Server=localhost;Database=MyApp;User Id=admin;Password=admin123;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
 
            string query = "SELECT * FROM Users WHERE Username = '" + username + "' AND Password = '" + password + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
 
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine("Login successful!");
            }
            else
            {
                Console.WriteLine("Invalid credentials.");
            }
 
            conn.Close();
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
