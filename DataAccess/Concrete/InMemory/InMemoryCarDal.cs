using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    internal class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>() { new Car { Id = 1, BrandId =2, ColorId =2, DailyPrice=2000 ,
             Description ="C#", ModelYear =2022},new Car { Id = 2, BrandId =2, ColorId =1, DailyPrice=3000 ,
             Description ="C", ModelYear =2021},new Car { Id = 3, BrandId =1, ColorId =1, DailyPrice=2500 ,
             Description ="C++", ModelYear =2015},new Car { Id = 4, BrandId =1, ColorId =2, DailyPrice=8000 ,
             Description ="Java", ModelYear =2022},new Car { Id = 5, BrandId =3, ColorId =5, DailyPrice=5000 ,
             Description ="Python", ModelYear =2020} };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car ToDelete = _cars.Single(q => q.Id == car.Id);

            _cars.Remove(ToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Car Get(Func<Car, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Func<Car, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int BrandId)
        {
            return _cars.Where(q => q.BrandId == BrandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        //public List<CarDetailDto> GetCarDetails()
        //{
        //    throw new NotImplementedException();
        //}

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByColorId(int ColorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car ToUpdate = _cars.Single(q => q.Id == car.Id);

            ToUpdate.DailyPrice = car.DailyPrice;
            ToUpdate.ModelYear = car.ModelYear;
            ToUpdate.ColorId = car.ColorId;
            ToUpdate.BrandId = car.BrandId;
            ToUpdate.Description = car.Description;
        }
    }
}
