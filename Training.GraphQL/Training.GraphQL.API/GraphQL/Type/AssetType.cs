using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.Model;

namespace Training.GraphQL.API.GraphQL
{
    public class AssetType: ObjectGraphType<Asset>
    {
        public AssetType()
        {
            Field(x => x.Id, nullable: false).Description("Id of asset");
            Field(x => x.Name, nullable: false).Description("Name of asset");
        }
    }
}
