using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Businees.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();

        IDataResult<Color> GetById(int id);

        IResult Add(Color color);

        IResult Update(Color color);

        IResult Delete(Color color);

    }
}
