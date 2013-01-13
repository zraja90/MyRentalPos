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
        public StoreService(IRepository<Store> repo) : base(repo)
        {
        }
    }
}