using Businees.Abstract;
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
    public class ColorManager : IColorService
    {
        IColorDal _color;

        public ColorManager(IColorDal colorDal)
        {
            _color = colorDal;
        }

        [ValidationAspect(typeof(Colorvalidator))]
        public IResult Add(Color color)
        {
            _color.Add(color);
            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            _color.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_color.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_color.Get(q => q.Id == id));
        }


		[ValidationAspect(typeof(Colorvalidator))]
		public IResult Update(Color color)
        {
            _color.Update(color);
            return new SuccessResult();
        }
    }
}
