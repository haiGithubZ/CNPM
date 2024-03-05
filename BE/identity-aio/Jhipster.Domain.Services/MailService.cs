using System.Threading.Tasks;
using Jhipster.Crosscutting.Constants;
using Jhipster.Crosscutting.Enums;
using Jhipster.Domain;
using Jhipster.Domain.Services.Interfaces;
using Jhipster.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Jhipster.Domain.Services
{
    public class MailService : IMailService
    {
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        public MailService(IEmailSender emailSender, IConfiguration configuration)
        {
            _emailSender = emailSender;
            _configuration = configuration;
        }



        public virtual async Task SendPasswordResetMail(User user)
        {
            var temp = _configuration.GetValue<string>("EmailTemplate:PasswordReset");
            await _emailSender.SendEmailAsync(user.Email, "Yêu cầu mã đặt lại mật khẩu", string.Format(temp, user.Login, user.ResetKey));
            //TODO send reset Email
        }


        public virtual async Task SendActivationEmail(User user)
        {
            var temp = _configuration.GetValue<string>("EmailTemplate:ActivateAccount");
            await _emailSender.SendEmailAsync(user.Email, "Kích hoạt tài khoản", string.Format(temp, user.Login, GenLink(user.ActivationKey)));
            //TODO Activation Email
        }


        public virtual async Task SendCreationEmail(User user)
        {
            var temp = _configuration.GetValue<string>("EmailTemplate:AdminCreation");
            await _emailSender.SendEmailAsync(user.Email, "Cấp mật khẩu tạm thời (Admin)", string.Format(temp, user.Login, user.ResetKey));
            //TODO Creation Email
        }

        public virtual async Task SendPasswordForgotOTPMail(User user)
        {
            var temp = _configuration.GetValue<string>("EmailTemplate:OTPFwPass");
            await _emailSender.SendEmailAsync(user.Email, "Yêu cầu mã bảo mật", string.Format(temp, user.Login, user.ResetKey));
            //TODO send reset Email
        }


        public virtual async Task SendConfirmedOTPMail(User user)
        {
            var temp = _configuration.GetValue<string>("EmailTemplate:OTPvetifiedEmail");
            await _emailSender.SendEmailAsync(user.Email, "Yêu cầu mã bảo mật", string.Format(temp, user.Login, user.ResetKey));
            //TODO send reset Email
        }

        public virtual async Task SendPasswordForgotResetMail(string newPassword, string mail)
        {
            var temp = _configuration.GetValue<string>("EmailTemplate:PasswordTemp");
            await _emailSender.SendEmailAsync(mail, "Cấp mật khẩu tạm thời (Quên mật khẩu)", string.Format(temp, "", newPassword));
            //TODO send reset Email
        }


        private string GenLink(string key)
        {
            var temp = _configuration.GetConnectionString("AIO");
            return $"{temp}/api/activate?key={key}";
        }
    }
}
