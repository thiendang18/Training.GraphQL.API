using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.IRepositories;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.GraphQLDemo.GraphQLTypes
{
    public class UserAssetType : ObjectGraphType<UserAsset>
    {
        public UserAssetType(IUserRepository userRepository, IAssetRepository assetRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id of UserAsset");
            Field(x => x.UserId).Description("Id of user");
            Field<UserType>(
                    "user",
                    resolve: context =>
                    {
                        return userRepository.GetUser(context.Source.UserId);
                    });
            Field<AssetType>(
                    "asset",
                    resolve: context =>
                    {
                        return assetRepository.GetAsset(context.Source.AssetId);
                    });
        }
    }
}
