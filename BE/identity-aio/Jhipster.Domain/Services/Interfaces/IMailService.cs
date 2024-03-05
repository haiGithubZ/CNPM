using System.Threading.Tasks;
using Jhipster.Domain;

namespace Jhipster.Domain.Services.Interfaces
{
    public interface IMailService
    {
        Task SendPasswordResetMail(User user);
        Task SendActivationEmail(User user);
        Task SendCreationEmail(User user);
        Task SendPasswordForgotOTPMail(User user);
        Task SendPasswordForgotResetMail(string newPassword, string mail);
        Task SendConfirmedOTPMail(User user);
    }
}
