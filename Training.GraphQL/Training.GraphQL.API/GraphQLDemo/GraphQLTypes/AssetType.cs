using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.IRepositories;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.GraphQLDemo.GraphQLTypes
{
    public class AssetType : ObjectGraphType<Asset>
    {
        public AssetType(IUserAssetRepository userAssetRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id of Asset");
            Field(x => x.Name).Description("Name of Asset");
            Field(x => x.Source).Description("Source of Asset");
            Field(x => x.UserAssetId).Description("Id of Asset");
            Field<ListGraphType<UserAssetType>>(
                "userAssets",
                resolve: context =>
                {
                    return userAssetRepository.GetUserAssetsByAssetId(context.Source.Id);
                });
           
        }
    }
}
