using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Stores;
using MyRentalPos.Data;

namespace MyRentalPos.Services.Stores
{
    public class StoreService : CrudService<Store>, IStoreService
    {
        private IRepository<StoreAddress> _storeAddressRepo ;
        public StoreService(IRepository<Store> repo, IRepository<StoreAddress> storeAddressRepo) : base(repo)
        {
            _storeAddressRepo = storeAddressRepo;
        }
    }
}