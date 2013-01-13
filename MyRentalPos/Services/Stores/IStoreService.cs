using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRentalPos.Core.Domain.Stores;

namespace MyRentalPos.Services.Stores
{
    public interface IStoreService : ICrudService<Store>
    {
    }
}
