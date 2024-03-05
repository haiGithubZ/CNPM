using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jhipster.Crosscutting.Constants;
using Jhipster.Crosscutting.Exceptions;
using Jhipster.Domain;
using Jhipster.Dto;
using Jhipster.Dto.Authentication;
using Jhipster.Dto.ProfileInfo;

namespace Jhipster.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(User userToCreate);
        IEnumerable<string> GetAuthorities();
        Task DeleteUser(string login);
        Task<User> UpdateUser(User userToUpdate);
        Task<User> CompletePasswordReset(string newPassword, string key);
        Task<User> RequestPasswordReset(string mail);
        Task<bool> ChangePassword(string currentClearTextPassword, string newPassword);
        Task<User> ActivateRegistration(string key);
        Task<User> DeActivateRegistration(string id);
        Task<User> RegisterUser(User userToRegister, string password);
        //Task UpdateUser(string firstName, string lastName, string email, string langKey, string imageUrl, string phoneNumber);
        Task<bool> UpdateUser(string email,string phoneNumber);
        Task<ChangeInfoDto> UserInformation();
        Task<User> GetUserWithUserRoles();
        Task<User> AdminPasswordReset(string login, string newPassword);
        Task<List<ForgotPasswordMethodRsDTO>> ForgotPasswordMethod(string login);
        Task<User> RequestOTPFWPass(string login, string type, string value);
        Task<bool> CompleteFwPassWord(string login, string key, string newPassWord);
        Task<bool> CompleteVerifiedEmail(string login, string key);
        Task<string> CheckOTP(string login, string key);
        string GetReferralCodeByUsername(string name);
        string GetFullnameByReferralCode(string ReferalCode);
        string GetFullnameByUsername(string username);
        Task<bool> CheckExistedUser(string ReferCode);
        Task<string> GetUserIdByUsername(string username);
        Task<UserDto> UserInformationById(string Id);
    }
}
