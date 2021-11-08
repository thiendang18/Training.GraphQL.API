using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.GraphQL.API.GraphQLDemo.GraphQLInput
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "userInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<LongGraphType>>("roleId");
            Field<NonNullGraphType<LongGraphType>>("departmentId");
        }
    }
}
