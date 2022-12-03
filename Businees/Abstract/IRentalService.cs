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
        public IResult Add(Rental rental);

        public IResult Delete(Rental rental);

        public IResult Update(Rental rental);

        public IDataResult<Rental> GetById(int rentalid);

        public IDataResult<List<Rental>> GetAll();
    }
}
