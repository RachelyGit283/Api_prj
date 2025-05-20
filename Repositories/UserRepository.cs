using System.Reflection.Metadata;
using System.Text.Json;

using System.Diagnostics;
using System.Linq.Expressions;
using Entities;
namespace Repositories
{
    public class UserRepository
    {
        private static readonly List<Users> users = new List<Users>();
        public Users getUserById(int id) 
        {

            foreach (var item in users)
            {
                if (item.userId == id)
                    return item;
            }
            return null;
        }
        public Users addUser(Users user) 
        {
            int numberOfUsers = System.IO.File.ReadLines("C:\\Users\\215085283\\Desktop\\users.txt").Count();
            user.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText("C:\\Users\\215085283\\Desktop\\users.txt", userJson + Environment.NewLine);
            return user;
        }
        public List<Users> getAllUsers() {

            return users;
        }
        public Users login(Users newUser)
        {
            using (StreamReader reader = System.IO.File.OpenText("C:\\Users\\215085283\\Desktop\\users.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.username == newUser.username && user.password == newUser.password)
                        return user;
                }
            }
            return null;
        }
        public Users updateUser(int id,Users userUpdate)
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
            return userUpdate;
        }

    }
}
