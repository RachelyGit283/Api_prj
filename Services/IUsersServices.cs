using DTO;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    //public interface IUsersServices
    //{
    //    public bool ValidatePasswordStrength(string password);
    //    public Task<User> GetUserById(int id);
    //    public Task Register(User user);
    //    public Task<User> Login(LoginUser loginUser);
    //    public Task<User> UpdateUser(int id, User userToUpdate);

    //}
    public interface IUsersServices
    {
        public bool ValidatePasswordStrength(string password);
        public Task<UserDto> GetUserById(int id);
        public Task<UserDto> Register(RegisterUserDto user);
        public Task<UserDto> Login(LoginUserDto loginUser);
        public Task<UserDto> UpdateUser(int id, RegisterUserDto userToUpdate);

    }
}
