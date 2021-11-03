using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.IService;
using Training.GraphQL.API.Model;

namespace Training.GraphQL.API.Service
{
    public class UserService: IUserService
    {
        List<User> users = new List<User>();
        public UserService() 
        {
            users.Add(new User { Id = 1, Name = "Jon" });
            users.Add(new User { Id = 2, Name = "Lemon" });
            users.Add(new User { Id = 3, Name = "Sun" });
        }
        public User GetById(long id)
        {
            return users.SingleOrDefault(x => x.Id.Equals(id));
        }
    }
}
