using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.Model;

namespace Training.GraphQL.API.IService
{
    public interface IUserAssetService
    {
        public List<UserAsset> GetAll();
        public UserAsset GetById(long id);
        public List<UserAsset> CreateUserAsset(UserAsset userAsset);
        public List<UserAsset> UpdateUserAsset(UserAsset userAssetUpdate, UserAsset userAsset);
        public List<UserAsset> DeleteUserAsset(UserAsset userAsset);
    }
}
