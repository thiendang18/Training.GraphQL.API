using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.IRepositories;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly List<Asset> assets = new List<Asset>()
        {
            new Asset { Id = 1, Name = "Keyboard", Source = "Google", UserAssetId = 1},
            new Asset { Id = 2, Name = "Screen", Source = "Amazon", UserAssetId = 2},

        };
        public Asset GetAsset(long id)
        {
            return assets.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Asset> GetAssets()
        {
            return assets;
        }
    }
}
