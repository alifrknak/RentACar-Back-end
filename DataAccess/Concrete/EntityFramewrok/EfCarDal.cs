using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramewrok
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentContext>, ICarDal
    {
        public CarDetailDto GetCarDetails(int carId)
        {
            // CarName, BrandName, ColorName, DailyPrice

            using (RentContext context = new RentContext())
            {
                var result = from i in context.Cars
                             join c in context.Colors
                             on i.ColorId equals c.Id
                             join b in context.Brands
                             on i.BrandId equals b.Id
                             where i.Id == carId
                             select new CarDetailDto()
                             {
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 DailyPrice = i.DailyPrice,
                                 Descrip = i.Description
                             };

                return result.ToList()[0];
            }

        }
    }
}