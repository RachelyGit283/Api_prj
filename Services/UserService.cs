using Entities;
using Repositories;
using System.Text.Json;
using System;
using Zxcvbn;
namespace Services
{
    public class userService
    {
        //public userService()
        //{
            
        //}
        UserRepository userReposirory = new UserRepository();
        public Users getUserById(int id)
        {

            return userReposirory.getUserById(id);
        }
        public Users addUser(Users user)
        {
            var result = Zxcvbn.Core.EvaluatePassword(user.password);
            // הציון הוא בין 0 (חלשה מאוד) ל-4 (חזקה מאוד)
            if (result.Score == 4)
            {
                Console.WriteLine("הסיסמה מספיק חזקה, כניסה אושרה!");
            }
            else
            {
                Console.WriteLine("הסיסמה חלשה. יש לבחור סיסמה חזקה יותר.");
                return null;
            }
            return userReposirory.addUser(user);
        }
        public Users updateUser(int id,Users user)
        {
            return userReposirory.updateUser(id,user);
        }
        public Users login( Users user)
        {
            return userReposirory.login( user);
        }
        public List<Users> getAllUsers()
        {
            return userReposirory.getAllUsers();


        }
    }
}
