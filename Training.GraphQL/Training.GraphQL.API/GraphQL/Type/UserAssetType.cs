using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.IService;
using Training.GraphQL.API.Model;

namespace Training.GraphQL.API.GraphQL
{
    public class UserAssetType : ObjectGraphType<UserAsset>
    {
        IUserService _userService;
        IAssetService _assetService;
        public UserAssetType(IUserService userService, IAssetService assetService)
        {
            _userService = userService;
            _assetService = assetService;

            Name = "UserAsset";
            Description = "A property owned by a user";
            Field(x => x.Id, nullable: false).Description("Id of user asset");
            Field(x => x.UserId, nullable: false).Description("Id user");
            Field<UserType>(
                "user",
                resolve: context =>
                {
                    return _userService.GetById(context.Source.UserId);
                });
            Field(x => x.AssetId, nullable: false).Description("Id asset");
            Field<AssetType>(
                "asset",
                resolve: context =>
                {
                    return _assetService.GetById(context.Source.AssetId);
                });
        }
    }
}
