using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.IService;
using Training.GraphQL.API.Model;

namespace Training.GraphQL.API.Service
{
    public class UserAssetService : IUserAssetService
    {
        List<UserAsset> userAssets = new List<UserAsset>();
        public UserAssetService()
        {
            userAssets.Add(new UserAsset { Id = 1, UserId = 1, AssetId = 1 });
            userAssets.Add(new UserAsset { Id = 2, UserId = 2, AssetId = 2 });
            userAssets.Add(new UserAsset { Id = 3, UserId = 3, AssetId = 3 });
        }

        public List<UserAsset> CreateUserAsset(UserAsset userAsset)
        {
            var maxId = userAssets.Max(x => x.Id);
            userAsset.Id = maxId + 1;
            userAssets.Add(userAsset);
            return userAssets;
        }

        public List<UserAsset> DeleteUserAsset(UserAsset userAsset)
        {
            userAssets.Remove(userAsset);
            return userAssets;
        }

        public List<UserAsset> GetAll()
        {
            return userAssets;
        }

        public UserAsset GetById(long id)
        {
            return userAssets.SingleOrDefault(x => x.Id.Equals(id));
        }

        public List<UserAsset> UpdateUserAsset(UserAsset userAssetUpdate, UserAsset userAsset)
        {
            userAssetUpdate.UserId = userAsset.UserId;
            userAssetUpdate.AssetId = userAsset.AssetId;
            userAssets.Where(x => x.Id.Equals(userAssetUpdate.Id)).Select(x => userAssetUpdate).ToList();
            return userAssets;
        }
    }
}
