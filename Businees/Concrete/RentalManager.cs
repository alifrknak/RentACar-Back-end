using Businees.Abstract;
using Businees.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramewrok;
using Entities.Concrete;

namespace Businees.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarDal _carDal;
        ICustomerDal _customerDal;

        public RentalManager(IRentalDal rentalDal,ICarDal carDal,ICustomerDal customerDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
            _customerDal = customerDal;
        }

		[ValidationAspect(typeof(RentalValidator))]
		public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(
                CheckCustomerExist(rental.CustomerId),
                CheckCarExist(rental.CarId)
                );
          

            if(result == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

		
		public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }


		[ValidationAspect(typeof(RentalValidator))]
		public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);

            return new SuccessResult();
        }

        public IDataResult<Rental> GetById(int rentalid)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(q => q.Id == rentalid));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

		public IResult IsCarRental(int carId)
		{
            var result = BusinessRules.Run(
                CheckCarisRental(carId)
                );

            return result == null ? new SuccessResult() : new ErrorResult();
		}



		// business ruler 


		private IResult CheckCustomerExist(int customerId)
		{
          var valid =  _customerDal.Get(q => q.Id == customerId);

            if (valid ==null)
            {
                return  new ErrorResult();
            }
            return new SuccessResult();
		}

        private IResult CheckCarExist(int carId)
        {
            var valid = _carDal.Get(q => q.Id == carId);

			if (valid == null)
			{
				return new ErrorResult();
			}
			return new SuccessResult();

		}

        private IResult CheckCarisRental(int carId)
        {
            var rst = _rentalDal.GetAll(q => q.CarId == carId);

            if (rst.Count > 0)
            {
				var isNull = rst.Where(q => q.ReturnDate == null).Any();

                return !isNull ? new SuccessResult() : new ErrorResult();
			}

            return new SuccessResult();
		}
	}
}
