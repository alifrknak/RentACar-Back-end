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
        ICarDal _carDal;
        IBrandService _brandService;
        IColorService _colorService;

		public CarManager(ICarDal car, IBrandService brandService, IColorService colorService)
		{
			_carDal = car;
			_brandService = brandService;
			_colorService = colorService;
		}

		[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            var result = BusinessRules.Run
                (
                   CheckIfCarCountOfModelYearsCorrect(car.ModelYear),
                   CheckIfCarBrandExist(car.BrandId),
                   CheckIfCarColorExist(car.ColorId)
				);

            if (result == null)
            {
                _carDal.Add(car);
                return new SuccessResult();
            }
            return result;
        }


		public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

		public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetByBrand(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(q => q.BrandId == brandId));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(q => q.Id == id));
        }

        //view oluştur database de
        public IDataResult<CarDetailDto> GetCarDetails(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails(carId));
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

		public IDataResult<List<Car>> GetByColor(int colorId)
		{
            var rst = _carDal.GetAll(q => q.ColorId == colorId);

			return new SuccessDataResult<List<Car>>(rst);

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

		private IResult CheckIfCarColorExist(int colorId)
		{
		    var check = _colorService.GetById(colorId);

            return  check.Data != null ? new SuccessResult() : new ErrorResult();
		}
        
		private IResult CheckIfCarBrandExist(int brandId)
		{
            var check = _brandService.GetById(brandId);
			
            return check.Data != null ? new SuccessResult() : new ErrorResult();
		}
	}
}
