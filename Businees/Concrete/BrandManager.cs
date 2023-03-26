using Businees.Abstract;
using Businees.Constant;
using Businees.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businees.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            var rst = BusinessRules.Run(
                CheckBrandExits(brand.Name)
                );

            if (rst == null)
            {
				_brandDal.Add(brand);

				return new SuccessResult();
			}

            return rst;
        }

		

		public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour > 22)
            {
                return new ErrorDataResult<List<Brand>>(_brandDal.GetAll());
            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(q => q.Id == id));
        }

		public IResult CheckByName(string brandName)
		{
            var rst = _brandDal.Get(q => q.Name == brandName);

            return rst != null ? new SuccessResult() : new ErrorResult();

		}

		[ValidationAspect(typeof(BrandValidator))]
		public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }


		public IDataResult<Brand> GetByName(string name)
		{
            var rst = _brandDal.Get(q => q.Name == name);

            return rst != null ? new SuccessDataResult<Brand>(rst) : new ErrorDataResult<Brand>(rst);
		}


		//

		private IResult CheckBrandExits(string name)
		{
           var check =  _brandDal.Get(q => q.Name == name);

            return check == null ? new SuccessResult() : new ErrorResult();
		}

	}
}
