using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businees.Abstract
{
	public interface IAuthService
	{
		IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
		IDataResult<User> Login(UserForLoginDto userForLoginDto);
		IResult UserExist(string email);
		IDataResult<AccessToken> CreateAccesToken(User user);

	}
}
