using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.GraphQLDemo.GraphQLTypes
{
    public class DepartmentType : ObjectGraphType<Department>
    {
        public DepartmentType()
        {
            Field(x => x.Id, type:typeof(IdGraphType)).Description("Id of Department");
            Field(x => x.Name).Description("Name of Department");
        }
    }
}
