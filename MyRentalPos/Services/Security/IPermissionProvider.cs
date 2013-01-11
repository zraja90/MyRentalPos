using System.Collections.Generic;
using MyRentalPos.Core.Domain.Security;

namespace MyRentalPos.Services.Security
{
    public interface IPermissionProvider
    {
        IEnumerable<PermissionRecord> GetPermissions();
        IEnumerable<DefaultPermissionRecord> GetDefaultPermissions();
    }
}
