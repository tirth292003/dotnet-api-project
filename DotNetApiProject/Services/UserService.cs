using System.Collections.Generic;
using System.Linq;
using DotNetApiProject.Models;

namespace DotNetApiProject.Services
{
    public class UserService
    {
        private readonly List<User> _users = new List<User>();

        public List<User> GetAllUsers() => _users;

        public User GetUserById(int id) => _users.FirstOrDefault(u => u.Id == id);

        public void AddUser(User user) => _users.Add(user);

        public bool UpdateUser(int id, User updatedUser)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null) return false;

            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            return true;
        }

        public bool DeleteUser(int id) => _users.Remove(_users.FirstOrDefault(u => u.Id == id));
    }
}
