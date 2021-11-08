using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.IRepositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUsers();
        public User GetUser(long id);
        public List<User> CreateUser(User user);
        public void DeleteUser(long id);
        public User UpdateUser(User dbUser, User user);
    }
}
