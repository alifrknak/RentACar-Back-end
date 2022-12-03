using Businees.Abstract;
using Businees.Constant;
using Businees.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        IBrandDal _brand;

        public BrandManager(IBrandDal brandDal)
        {
            _brand = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            if (brand.Name.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInValid);
            }
            _brand.Add(brand);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brand.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour > 22)
            {
                return new ErrorDataResult<List<Brand>>(_brand.GetAll(), Messages.Maintenancetime);
            }

            return new SuccessDataResult<List<Brand>>(_brand.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brand.Get(q => q.Id == id));
        }


		[ValidationAspect(typeof(BrandValidator))]
		public IResult Update(Brand brand)
        {
            _brand.Update(brand);
            return new SuccessResult();
        }
    }
}
