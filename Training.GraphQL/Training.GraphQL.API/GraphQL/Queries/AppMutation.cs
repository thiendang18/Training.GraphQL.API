using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.GraphQL.TypeInput;
using Training.GraphQL.API.IService;
using Training.GraphQL.API.Model;

namespace Training.GraphQL.API.GraphQL.Queries
{
    public class AppMutation: ObjectGraphType
    {
        IUserAssetService _userAssetService;
        public AppMutation(IUserAssetService userAssetService)
        {
            _userAssetService = userAssetService;
            Field<ListGraphType<UserAssetType>>(
                "createUserAsset",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserAssetInput>> { Name = "userAssetInput" }),
                resolve: context =>
                {
                    var userAsset = context.GetArgument<UserAsset>("userAssetInput");
                    return _userAssetService.CreateUserAsset(userAsset);
                });
            Field<ListGraphType<UserAssetType>>(
                "updateUserAsset",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserAssetInput>> { Name = "userAssetInput" },
                    new QueryArgument<NonNullGraphType<LongGraphType>> { Name = "userAssetId"}),
                resolve: context =>
                {
                    var userAsset = context.GetArgument<UserAsset>("userAssetInput");
                    var userAssetId = context.GetArgument<long>("userAssetId");

                    var userAssetUpdate = _userAssetService.GetById(userAssetId);
                    if (userAssetUpdate == null)
                    {
                        throw new ExecutionError("Invalid userAssetId");
                    }

                    return _userAssetService.UpdateUserAsset(userAssetUpdate, userAsset);
                });
            Field<ListGraphType<UserAssetType>>(
                "deleteUserAsset",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LongGraphType>> { Name = "userAssetId" }),
                resolve: context =>
                {
                    var userAssetId = context.GetArgument<long>("userAssetId");
                    var userAssetRemove = _userAssetService.GetById(userAssetId);
                    if (userAssetRemove == null)
                    {
                        throw new ExecutionError("Invalid userAssetId");
                    }
                    return _userAssetService.DeleteUserAsset(userAssetRemove);
                });
        }
    }
}
