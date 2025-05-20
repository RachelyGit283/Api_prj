
using Microsoft.AspNetCore.Mvc;
using My_Store.Controllers;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.Json;
using Services;
using Entities;
using Umbraco.Core.Services.Implement;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace My_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        userService userService = new userService();
        //private static readonly List<Users> users = new List<Users>();
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult< IEnumerable<Users>> Get()
        {
            
            List<Users> users =userService.getAllUsers();
            if (users.Count > 0)
                return Ok(users);
            return NoContent();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id)
        {
            Users users = userService.getUserById(id);
            if (users==null) return NoContent();
            return Ok(users);
           
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users user)
        {
            Users newUser = userService.addUser(user);
            //int numberOfUsers = System.IO.File.ReadLines("C:\\Users\\215085283\\Desktop\\users.txt").Count();
            //user.userId = numberOfUsers + 1;
            //string userJson = JsonSerializer.Serialize(user);
            //System.IO.File.AppendAllText("C:\\Users\\215085283\\Desktop\\users.txt", userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.userId }, newUser);
        }

        [HttpPost("login")]
        public ActionResult<Users> Login([FromBody] Users newUser)
        {
            Users users = userService.login(newUser);
            if (users == null) return NotFound(new { Message = "User not found." });
            return Ok(users);
            //using (StreamReader reader = System.IO.File.OpenText("C:\\Users\\215085283\\Desktop\\users.txt"))
            //{
            //    string? currentUserInFile;
            //    while ((currentUserInFile = reader.ReadLine()) != null)
            //    {
            //        Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
            //        if (user.username == newUser.username && user.password == newUser.password)
            //            return Ok(user);
            //    }
            //}
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<Users> Put(int id, [FromBody] Users userUpdate)
        {
            Users users = userService.updateUser(id, userUpdate);
            if (users == null) return NoContent();
            return Ok(users);
            //string textToReplace = string.Empty;
            //using (StreamReader reader = System.IO.File.OpenText("C:\\Users\\215085283\\Desktop\\users.txt"))
            //{
            //    string currentUserInFile;
            //    while ((currentUserInFile = reader.ReadLine()) != null)
            //    {

            //        Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
            //        if (user.userId == id)
            //            textToReplace = currentUserInFile;
            //    }
            //}

            //if (textToReplace != string.Empty)
            //{
            //    string text = System.IO.File.ReadAllText("C:\\Users\\215085283\\Desktop\\users.txt");
            //    text = text.Replace(textToReplace, JsonSerializer.Serialize(userUpdate));
            //    System.IO.File.WriteAllText("C:\\Users\\215085283\\Desktop\\users.txt", text);
            //}
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

