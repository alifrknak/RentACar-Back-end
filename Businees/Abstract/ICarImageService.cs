using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Businees.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();

        IDataResult<CarImage> GetById(int id);

        IDataResult<List<CarImage>> GetImagesByCarId(int id);
        IResult Add(CarImage carImage);

        IResult Update(CarImage carImage);

        IResult Delete(CarImage carImage);
    }
}
