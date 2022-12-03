using Businees.Abstract;
using Businees.BusinessAspect.Autofac;
using Businees.Constant;
using Businees.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Businees.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _car;

        public CarManager(ICarDal car)
        {
            _car = car;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            var result = BusinessRules.Run
                (
                   CheckIfCarCountOfBrandCorrect(car.BrandId),
                   CheckIfCarCountOfModelYearsCorrect(car.ModelYear)
                );

            if (result == null)
            {
                _car.Add(car);
                return new SuccessResult();
            }
            return result;
        }

        public IResult Delete(Car car)
        {
            _car.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_car.GetAll());
        }

        public IDataResult<List<Car>> GetByBrand(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_car.GetAll(q => q.BrandId == brandId));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_car.Get(q => q.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_car.GetCarDetails());
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _car.Update(car);
            return new SuccessResult();
        }




        ///
        //
        //
        //
        ///

        private IResult CheckIfCarCountOfModelYearsCorrect(int modelYear)
        {
            if (modelYear < 1980)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            int result = _car.GetAll(q => q.BrandId == brandId).Count;

            if (result >= 20)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

    }
}
