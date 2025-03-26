//using Microsoft.AspNetCore.Http.HttpResults;

//using Microsoft.AspNetCore.Mvc;
//using System.Text.Json;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace My_Store.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        // GET: api/<UsersController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<UsersController>/5
//        [HttpGet("{id}")]
//        public ActionResult<Users> Get(int id)
//        {
//            using (StreamReader reader = System.IO.File.OpenText("users"))
//            {
//                string? currentUserInFile;
//                while ((currentUserInFile = reader.ReadLine()) != null)
//                {
//                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
//                    if (user?.userId == id)
//                        return Ok(user);
//                }
//            }
//            return NoContent();
//        }

//        // POST api/<UsersController>
//        [HttpPost]
//        public ActionResult<Users> Post([FromBody] Users users)
//        {
//        int numberOfUsers = System.IO.File.ReadLines("./Users.txt").Count();
//            Console.WriteLine("aaa");
//            users.userId = numberOfUsers + 1;
//            string userJson = JsonSerializer.Serialize(users);
//            System.IO.File.AppendAllText("./User.txt", userJson + Environment.NewLine);
//            return CreatedAtAction(nameof(Get), new { id = users.userId }, users);

//        }
//        //[HttpPost("register")]
//        //public ActionResult<Users> Register([FromBody] Users user)
//        //{
//        //    if (user is null)
//        //        return StatusCode(400, "user is required");
//        //    if (string.IsNullOrEmpty(user.password) || string.IsNullOrEmpty(user.nameUser))
//        //        return StatusCode(400, "Password and UserName are required");
//        //    try
//        //    {
//        //        int numberOfUsers = System.IO.File.Exists("users.txt") ? System.IO.File.ReadLines("users.txt").Count() : 0;
//        //        user.userId = numberOfUsers + 1;
//        //        if (System.IO.File.Exists("users.txt"))
//        //        {
//        //            var existingUsers = System.IO.File.ReadLines("users.txt").Select(line => JsonSerializer.Deserialize<Users>(line)).ToList();
//        //            if (existingUsers.Any(u => u.nameUser == user.nameUser))
//        //                return StatusCode(400, "Username is already taken");
//        //        }
//        //        string userJson = JsonSerializer.Serialize(user);
//        //        System.IO.File.AppendAllText("users", userJson + Environment.NewLine);
//        //        return CreatedAtAction(nameof(Get), new { id = user.userId }, user);
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return StatusCode(500, "Error writing user to file: " + ex.Message);
//        //    }
//        //}

//        //[HttpPost("login")]
//        //public ActionResult<Users> login([FromBody] object loginRequest)
//        //{
//        //    if (string.IsNullOrEmpty(loginRequest?.password) || string.IsNullOrEmpty(loginRequest?.nameUser))
//        //        return StatusCode(400, "Password and UserName are required");
//        //    try
//        //    {
//        //        if (!System.IO.File.Exists("users.txt"))
//        //        {
//        //            return NotFound("No users found.");
//        //        }

//        //        using (StreamReader reader = System.IO.File.OpenText("users.txt"))
//        //        {
//        //            string? currentUserInFile;
//        //            while ((currentUserInFile = reader.ReadLine()) != null)
//        //            {
//        //                Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
//        //                if (user.nameUser == loginRequest.nameUser && user.password == loginRequest.password)
//        //                {
//        //                    return Ok(user);
//        //                }
//        //            }
//        //        }
//        //        return Unauthorized("Invalid username or password.");
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return StatusCode(500, "Error reading users from file: " + ex.Message);
//        //    }
//        //}
//        // PUT api/<UsersController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] Users userToUpdate)
//        {
//            string textToReplace = string.Empty;
//            using (StreamReader reader = System.IO.File.OpenText("users"))
//            {
//                string currentUserInFile;
//                while ((currentUserInFile = reader.ReadLine()) != null)
//                {
//                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
//                    if (user?.userId == id)
//                        textToReplace = currentUserInFile;
//                }
//            }

//            if (textToReplace != string.Empty)
//            {
//                string text = System.IO.File.ReadAllText("users");
//                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
//                System.IO.File.WriteAllText("users", text);
//            }
//        }

//        // DELETE api/<UsersController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using My_Store.Controllers;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace My_Store.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static readonly List<Users> users = new List<Users>();
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users user)
        {
            int numberOfUsers = System.IO.File.ReadLines("C:\\Users\\215085283\\Desktop\\users.txt").Count();
            user.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText("C:\\Users\\215085283\\Desktop\\users.txt", userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.userId }, user);
        }

        [HttpPost("login")]
        public ActionResult<Users> Login([FromBody] Users newUser)
        {
            using (StreamReader reader = System.IO.File.OpenText("C:\\Users\\215085283\\Desktop\\users.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.username == newUser.username && user.password == newUser.password)
                        return Ok(user);
                }
            }
            return NotFound(new { Message = "User not found." });
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users userUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText("C:\\Users\\215085283\\Desktop\\users.txt"))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.userId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText("C:\\Users\\215085283\\Desktop\\users.txt");
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userUpdate));
                System.IO.File.WriteAllText("C:\\Users\\215085283\\Desktop\\users.txt", text);
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

