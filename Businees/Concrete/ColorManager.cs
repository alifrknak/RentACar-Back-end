using Businees.Abstract;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(Colorvalidator))]
        public IResult Add(Color color)
        {

			var rst = BusinessRules.Run(
				CheckBrandExits(color.Name)
				);

			if (rst == null)
			{
				_colorDal.Add(color);

				return new SuccessResult();
			}

			return rst; ;
        }

		public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(q => q.Id == id));
        }

		public IResult CheckByName(string colorName)
		{
            var rst = _colorDal.Get(q => q.Name == colorName);

            return rst != null ? new SuccessResult() : new ErrorResult();
		}

		[ValidationAspect(typeof(Colorvalidator))]
		public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult();
        }
		public IDataResult<Color> GetByName(string colorName)
		{
            var rst = _colorDal.Get(q => q.Name == colorName);

			return rst != null ? new SuccessDataResult<Color>(rst) : new ErrorDataResult<Color>(rst);

		}


		///

		private IResult CheckBrandExits(string name)
		{
			var check = _colorDal.Get(q => q.Name == name);

			return check == null ? new SuccessResult() : new ErrorResult();
		}

		
	}
}
