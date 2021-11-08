using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.Models;

namespace Training.GraphQL.API.IRepositories
{
    public interface IUserAssetRepository
    {
        public IEnumerable<UserAsset> GetUserAssets();
        public UserAsset GetUserAsset(long id);
        public IEnumerable<UserAsset> GetUserAssetsByAssetId(long assetId);
        public IEnumerable<UserAsset> GetUserAssetsByUserId(long userId);
    }
}
