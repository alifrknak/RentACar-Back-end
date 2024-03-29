﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businees.Abstract
{
    public interface ICustomerService
    {
        public IResult Add(Customer customer);

        public IResult Delete(Customer customer);

        public IResult Update(Customer customer);

        public IDataResult<Customer> GetById(int customerid);

        public IDataResult<List<Customer>> GetAll();
    }
}
