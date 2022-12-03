using Businees.Abstract;
using Businees.Constant;
using Businees.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Businees.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userdal;

        public UserManager(IUserDal userDal)
        {
            _userdal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User User)
        {
            _userdal.Add(User);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(User User)
        {
            _userdal.Delete(User);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userdal.GetAll());
        }

        public IDataResult<User> GetById(int userid)
        {
            return new SuccessDataResult<User>(_userdal.Get(q => q.Id == userid));
        }

		[ValidationAspect(typeof(UserValidator))]
		public IResult Update(User User)
        {
            _userdal.Update(User);

            return new SuccessResult();
        }
    }
}
