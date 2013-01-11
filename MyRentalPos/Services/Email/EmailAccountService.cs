using MyRentalPos.Core.Domain.Email;
using MyRentalPos.Data;

namespace MyRentalPos.Services.Email
{
    public partial class EmailAccountService : CrudService<EmailAccount>, IEmailAccountService
    {
        public EmailAccountService(IRepository<EmailAccount> repo) : base(repo)
        {
        }


    }
}
