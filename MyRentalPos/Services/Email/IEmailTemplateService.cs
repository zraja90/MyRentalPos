using System.Collections.Generic;
using MyRentalPos.Core.Domain.Email;

namespace MyRentalPos.Services.Email
{
    public partial interface IEmailTemplateService : ICrudService<EmailTemplates>
    {
        EmailTemplates GetMessageTemplateByName(int programId, string messageTemplateName);
        IList<EmailTemplates> GetAllMessageTemplates(int programId);

        void InitSettings(int programId);
        
    }
}
