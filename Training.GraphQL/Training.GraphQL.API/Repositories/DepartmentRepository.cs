using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.IRepositories;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly List<Department> departments = new List<Department>()
        {
            new Department { Id = 1, Name = "Server"},
            new Department { Id = 2, Name = "Sales"},

        };
        public IEnumerable<Department> GetDepartments()
        {
            return departments;
        }

        public Department GetDepartment(long id)
        {
            return departments.SingleOrDefault(x => x.Id == id);
        }
    }
}
