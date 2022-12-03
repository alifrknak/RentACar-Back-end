using Businees.Abstract;
using Businees.Constant;
using Businees.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramewrok;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Businees.Concrete
{
    public partial class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

		public List<OperationClaim> GetClaims(User user)
		{
			return _userDal.GetClaims(user);
		}
		
		public void Add(User user)
		{
			_userDal.Add(user);
		}

		public User? GetByMail(string email)
		{
			return _userDal.Get(q=> q.Email == email);
		}
	}
}
