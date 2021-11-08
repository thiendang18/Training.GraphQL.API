using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.GraphQLDemo.GraphQLTypes;
using Training.GraphQL.API.IRepositories;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.GraphQLDemo.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IUserRepository userRepository)
        {
            Field<ListGraphType<UserType>>("users",
                resolve: context => userRepository.GetUsers());
            Field<UserType>("user",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LongGraphType>> { Name = "userId" }),
                resolve: context =>
                {
                    var userId = context.GetArgument<long>("userId");
                    var user = userRepository.GetUser(userId);
                    if (user is null)
                    {
                        throw new ExecutionError("Don't have user");
                    }
                    return user;
                });

        }
    }
}
