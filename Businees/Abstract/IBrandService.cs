using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businees.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();

		IResult CheckByName(string brandName);

		IDataResult<Brand> GetById(int id);

		IResult Add(Brand brand);

        IResult Update(Brand brand);

        IResult Delete(Brand brand);

        IDataResult<Brand> GetByName(string name);
    }
}
