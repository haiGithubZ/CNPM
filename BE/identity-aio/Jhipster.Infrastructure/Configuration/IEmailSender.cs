using System.Threading.Tasks;

namespace Jhipster.Infrastructure.Configuration
{
    //
    // Summary:
    //     This API supports the ASP.NET Core Identity default UI infrastructure and is
    //     not intended to be used directly from your code. This API may change or be removed
    //     in future releases.
    public interface IEmailSender
    {
        //
        // Summary:
        //     This API supports the ASP.NET Core Identity default UI infrastructure and is
        //     not intended to be used directly from your code. This API may change or be removed
        //     in future releases.
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
