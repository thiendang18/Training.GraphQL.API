using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.IService;
using Training.GraphQL.API.Model;

namespace Training.GraphQL.API.Service
{
    public class AssetService: IAssetService
    {
        List<Asset> assets = new List<Asset>();
        public AssetService()
        {
            assets.Add(new Asset { Id = 1, Name = "Mouse" });
            assets.Add(new Asset { Id = 2, Name = "Desktop" });
            assets.Add(new Asset { Id = 3, Name = "Pen" });
        }
        public Asset GetById(long id)
        {
            return assets.SingleOrDefault(x => x.Id.Equals(id));
        }
    }
}
