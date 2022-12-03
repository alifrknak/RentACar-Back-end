using Businees.Abstract;
using Businees.Constant;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Businees.Concrete
{
	public partial class UserManager
	{
		public class AuthManager : IAuthService
		{
			private IUserService _userService;
			private ITokenHelper _tokenHelper;

			public AuthManager(IUserService userService, ITokenHelper tokenHelper)
			{
				_userService = userService;
				_tokenHelper = tokenHelper;
			}

			public IDataResult<AccessToken> CreateAccesToken(User user)
			{
				var claim = _userService.GetClaims(user);
				var accessToken = _tokenHelper.CreateToken(user, claim);

				return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokencreate);
			}

			public IDataResult<User> Login(UserForLoginDto userForLoginDto)
			{
				var userCheck = _userService.GetByMail(userForLoginDto.Email);
				if (userCheck == null)
				{
					return new ErrorDataResult<User>(Messages.UserNotFound);
				}

				if (!HashingHelper.VerifyPasswordHash
					(userForLoginDto.Password, userCheck.PasswordHash, userCheck.PasswordSalt))
				{
					return new ErrorDataResult<User>(Messages.PasswordError);
				}

				return new SuccessDataResult<User>(userCheck, Messages.SuccessfulLogin);
			}

			public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
			{
				byte[] passwordHash, passwordSalt;

				HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

				if (UserExist(userForRegisterDto.Email).Success)
				{
					var user = new User()
					{
						First_name = userForRegisterDto.First_name,
						Last_name = userForRegisterDto.Last_name,
						Email = userForRegisterDto.Email,
						Status = true,
						PasswordHash = passwordHash,
						PasswordSalt = passwordSalt
					};
					_userService.Add(user);
					return new SuccessDataResult<User>(user, Messages.UserRegistered);
				}
				return new ErrorDataResult<User>(Messages.EmailIsUsing);
			}

			public IResult UserExist(string? email)
			{
				if (_userService.GetByMail(email) != null)
					return new ErrorResult(Messages.UserAlreadyExists);
				return new SuccessResult();
			}
		}
	}
}