using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.GraphQLDemo.GraphQLInput;
using Training.GraphQL.API.GraphQLDemo.GraphQLTypes;
using Training.GraphQL.API.IRepositories;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.GraphQLDemo.GraphQLMutation
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IUserRepository userRepository)
        {
            Field<ListGraphType<UserType>>(
                "createUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UserInputType>> {Name = "user" }),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    return userRepository.CreateUser(user);
                });
            Field<StringGraphType>(
                "deleteUser",
                 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId" }),
                 resolve: context =>
                  {
                      var userId = context.GetArgument<long>("userId");
                      userRepository.DeleteUser(userId);
                      return $"The user with the id: {userId} has been deleted";
                  });
            Field<UserType>(
                "updateUser",
                 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" },
                                               new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId" }),
                 resolve: context =>
                 {
                     var user = context.GetArgument<User>("user");
                     var userId = context.GetArgument<long>("userId");
                     var dbUser = userRepository.GetUser(userId);
                     if(dbUser is null)
                     {
                         context.Errors.Add(new ExecutionError("Couldn't find user"));
                         return null;
                     }
                     return userRepository.UpdateUser(dbUser, user);
                 });

        }
    }
}
