using FluentValidation;
using Microsoft.Extensions.Localization;
using PTM.BAL.Utilities.Common;
using PTM.DTO.DTOs;
namespace PTM.BAL.Validators
{
    public class UserToLoginDTOValidator : AbstractValidator<UserDTO>
    {
        private readonly IStringLocalizer<UserToLoginDTOValidator> _localizer;
        public UserToLoginDTOValidator(IStringLocalizer<UserToLoginDTOValidator> localizer)
        {
            _localizer = localizer;
            RuleFor(x => x.Username).EmailAddress().WithMessage(_localizer[name: ResponseMessage.InvalidUsername.ToString()]);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(12).WithMessage(_localizer[name: ResponseMessage.InvalidPasswordLength.ToString()]);
           
        }
    }
}
