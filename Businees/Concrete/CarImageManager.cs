using Businees.Abstract;
using Businees.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramewrok;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businees.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run
                 (
                CheckImageLimitExceeded(carImage)
                );

            if (result == null)
            {
                _carImageDal.Add(carImage);
                return new SuccessResult();
            }

            return new ErrorResult();
        }


        public IResult Delete(CarImage carImage)
        {
            var result = _carImageDal.GetAll(q => q.Id == carImage.Id).Count;
            if (result == 0)
            {
                _carImageDal.Delete(carImage);
                return new SuccessResult();
            }
            return new ErrorResult();

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(q => q.Id == id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(q => q.CarId == id));
        }

		[ValidationAspect(typeof(CarImageValidator))]
		public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }



        // business code 
        private IResult CheckImageLimitExceeded(CarImage carImage)
        {
            var result = _carImageDal.GetAll(q => q.CarId == carImage.CarId).Count;

            if (result < 5)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }
    }
}
