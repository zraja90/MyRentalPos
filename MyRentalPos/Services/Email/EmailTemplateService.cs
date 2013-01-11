using System.Collections.Generic;
using System.Linq;
using MyRentalPos.Core.Domain.Email;
using MyRentalPos.Data;

namespace MyRentalPos.Services.Email
{
    public partial class EmailTemplateService : CrudService<EmailTemplates>, IEmailTemplateService
    {
        public EmailTemplateService(IRepository<EmailTemplates> repo)
            : base(repo)
        {
        }


        public EmailTemplates GetMessageTemplateByName(int programId, string messageTemplateName)
        {
            return Get(x => x.ProgramId == programId && x.Name == messageTemplateName);
        }

        public IList<EmailTemplates> GetAllMessageTemplates(int programId)
        {
            return GetMany(x => x.ProgramId == programId).ToList();
        }

        public void InitSettings(int programId)
        {
            var settings = GetMany(x => x.ProgramId == 1);
            foreach (var item in settings)
            {
                var setting = item;
                setting.ProgramId = programId;
                repo.Add(setting);
            }

        }
    }
}
