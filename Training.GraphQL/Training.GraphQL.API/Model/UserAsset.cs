using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.GraphQL.API.Model
{
    public class UserAsset
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long AssetId { get; set; }
        public Asset Asset { get; set; }
    }
}
