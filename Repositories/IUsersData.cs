using DTO;
using Entities;


namespace Repositories
{
    public interface IUsersData
    {
        public Task<User> GetUserByIdFromDB(int id);
        public Task<User> Register(User user);
        public Task<User> Login(LoginUserDto loginUser);
        public Task<User> UpdateUser(int id, User userToUpdate);

    }
}
