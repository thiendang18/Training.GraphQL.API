using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.GraphQL.API.GraphQL.TypeInput
{
    public class UserAssetInput: InputObjectGraphType
    {
        public UserAssetInput()
        {
            Name = "UserAssetInput";
            Field<NonNullGraphType<LongGraphType>>("userId");
            Field<NonNullGraphType<LongGraphType>>("assetId");
        }
    }
}
