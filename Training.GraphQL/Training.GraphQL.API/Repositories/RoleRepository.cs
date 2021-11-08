using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.IRepositories;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly List<Role> roles = new List<Role>()
        {
            new Role { Id = 1, Name = "IT"},
            new Role { Id = 2, Name = "Admin"},

        };
        public IEnumerable<Role> GetRoles()
        {
            return roles;
        }

        public Role GetRole(long id)
        {
            return roles.SingleOrDefault(x => x.Id == id);
        }
    }
}
