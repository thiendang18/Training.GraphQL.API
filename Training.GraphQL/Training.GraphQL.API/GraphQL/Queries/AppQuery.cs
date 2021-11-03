using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.IService;

namespace Training.GraphQL.API.GraphQL
{
    public class AppQuery: ObjectGraphType
    {
        IUserAssetService _userAssetService;
        public AppQuery(IUserAssetService userAssetService)
        {
            _userAssetService = userAssetService;
            Field<ListGraphType<UserAssetType>>(
                "userAssets",
                resolve: context =>
                {
                    return _userAssetService.GetAll();
                });
            Field<UserAssetType>(
                "userAsset",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LongGraphType>> { Name = "userAssetId" }),
                resolve: context =>
                {
                    var userAssetId = context.GetArgument<long>("userAssetId");
                    var userAsset = _userAssetService.GetById(userAssetId);
                    if (userAsset == null)
                    {
                        throw new ExecutionError("Invalid userAssetId");
                    }
                    return userAsset;
                });
        }
    }
}
