using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.IRepositories
{
    public interface IRoleRepository
    {
        public IEnumerable<Role> GetRoles();
        public Role GetRole(long id);
    }
}
