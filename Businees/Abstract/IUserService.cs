using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businees.Abstract
{
    public interface IUserService
    {
        public IResult? Add(User User);

        public IResult? Delete(User User);

        public IResult Update(User User);

        public IDataResult<User> GetById(int userid);

        public IDataResult<List<User>> GetAll();
    }
}
