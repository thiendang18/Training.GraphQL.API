using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.IRepositories
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetDepartments();
        public Department GetDepartment(long id);
    }
}
