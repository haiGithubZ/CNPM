using Jhipster.Crosscutting.Constants;

namespace Jhipster.Crosscutting.Exceptions
{
    public class InvalidPasswordException : BaseException
    {
        public InvalidPasswordException() : base(ErrorConstants.InvalidPasswordType, "Incorrect Password")
        {
            //Status = StatusCodes.Status400BadRequest
        }
    }
    public class PasswordException : BaseException
    {
        public PasswordException() : base(ErrorConstants.InvalidPasswordType, "New Password Can't have same value with the old one")
        {
            //Status = StatusCodes.Status400BadRequest
        }
    }

}
