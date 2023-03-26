using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businees.Abstract
{
    public interface IRentalService
    {
         IResult Add(Rental rental);

         IResult Delete(Rental rental);

         IResult Update(Rental rental);

        IDataResult<Rental> GetById(int rentalid);

        IDataResult<List<Rental>> GetAll();

        IResult IsCarRental(int carId);

    }
}
