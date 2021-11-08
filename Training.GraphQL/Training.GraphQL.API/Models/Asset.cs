using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.GraphQL.API.Models
{
    public class Asset
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public long UserAssetId { get; set; }
        public List<UserAsset> UserAssets { get; set; }
    }
}
