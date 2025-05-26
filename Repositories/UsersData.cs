using Entities;

using Microsoft.EntityFrameworkCore;
using DTO;
namespace Repositories
{
    public class UsersData
          : IUsersData
    {
        StoreDB215085283Context _StoreDB215085283Context;

        public UsersData(StoreDB215085283Context storeDB215085283Context)
        {
            _StoreDB215085283Context = storeDB215085283Context;
        }
        public async Task<User> GetUserByIdFromDB(int id)
        {
            return await _StoreDB215085283Context.Users.FirstOrDefaultAsync(user => user.UserId == id);

        }


        public async Task<User> Register(User user)
        {
            try
            {
                if (await _StoreDB215085283Context.Users.AnyAsync(u => u.UserName == user.UserName))
                    throw new CustomApiException(409, "Username is already taken");
                await _StoreDB215085283Context.Users.AddAsync(user);
                await _StoreDB215085283Context.SaveChangesAsync();
                return user;
            }
            catch (CustomApiException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomApiException(500, "Error writing user to file: " + ex.Message);
            }
        }

        public async Task<User> Login(LoginUserDto loginUser)
        {
            var res = await _StoreDB215085283Context.Users.FirstOrDefaultAsync(user => user.UserName == loginUser.UserName && user.Password == loginUser.Password);
            Console.WriteLine(res);
            return res;
        }

        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            try
            {
                userToUpdate.UserId = id;
                //
                var existingUser = await _StoreDB215085283Context.Users.FindAsync(id);
                if (existingUser != null)
                {
                    _StoreDB215085283Context.Entry(existingUser).State = EntityState.Detached;
                }
                _StoreDB215085283Context.Update(userToUpdate);
                await _StoreDB215085283Context.SaveChangesAsync();

                return userToUpdate;
            }
            catch (Exception ex)
            {
                throw new CustomApiException(500, "Error updating user: " + ex.Message);
            }

        }
    }
}
