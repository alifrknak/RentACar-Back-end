using Businees.Abstract;
using Businees.Constant;
using Businees.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramewrok;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businees.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IUserDal _userDal;

        public CustomerManager(ICustomerDal customerDal, IUserDal userDal)
		{
			_customerDal = customerDal;
			_userDal = userDal;
		}

		[ValidationAspect(typeof(CustomerValidator))]
		public IResult Add(Customer customer)
        {
          var result = BusinessRules.Run(CheckUserExist(customer.UserId));

            if (result==null)
            {
                _customerDal.Add(customer);
                return new SuccessResult();
            }
			return new ErrorResult();
		}


		public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);

            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int customerid)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(q => q.Id == customerid));

        }


		[ValidationAspect(typeof(CustomerValidator))]
		public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);

            return new SuccessResult();
        }







        //business rulers



		private IResult CheckUserExist(int userId)
		{
          var valid =  _userDal.Get(q => q.Id == userId);

            if (valid == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
		}
	}
}
