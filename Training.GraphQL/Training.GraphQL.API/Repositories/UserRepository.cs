using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.IRepositories;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly List<User> users = new List<User>()
        {
            new User { Id = 1, Name = "dvbthien", RoleId = 1, DepartmentId = 1, UserAssetId = 1 },
            new User { Id = 2, Name = "dvbthien1", RoleId = 1, DepartmentId = 1, UserAssetId = 1 },
            new User { Id = 3, Name = "dvbthien2", RoleId = 2, DepartmentId = 2, UserAssetId = 2 },
            new User { Id = 3, Name = "dvbthien3", RoleId = 2, DepartmentId = 2, UserAssetId = 2 }
        };
        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public User GetUser(long id)
        {
            return users.SingleOrDefault(x => x.Id == id);
        }

        public List<User> CreateUser(User user)
        {
            user.Id = users.Max(x => x.Id) + 1;
            users.Add(user);
            return users;
        }

        public void DeleteUser(long id)
        {
            var index = users.FindIndex(item => item.Id == id);
            users.RemoveAt(index);
        }

        public User UpdateUser(User dbUser, User user)
        {
            dbUser.Name = user.Name;
            dbUser.RoleId = user.RoleId;
            dbUser.DepartmentId = user.DepartmentId;
            users.Where(x => x.Id == dbUser.Id).Select(x => dbUser).ToList();
            return dbUser;
        }
    }

}
