using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.IRepositories;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.Repositories
{
    public class UserAssetRepository : IUserAssetRepository
    {
        private readonly List<UserAsset> userAssets = new List<UserAsset>()
        {
            new UserAsset { Id = 1, UserId = 1, AssetId = 1},
            new UserAsset { Id = 2, UserId = 2, AssetId = 2},

        };
        public UserAsset GetUserAsset(long id)
        {
            return userAssets.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<UserAsset> GetUserAssets()
        {
            return userAssets;
        }
        public IEnumerable<UserAsset> GetUserAssetsByAssetId(long assetId)
        {
            return userAssets.FindAll(x => x.AssetId == assetId);
        }
        public IEnumerable<UserAsset> GetUserAssetsByUserId(long userId)
        {
            return userAssets.FindAll(x => x.UserId == userId);
        }
        
    }
}
