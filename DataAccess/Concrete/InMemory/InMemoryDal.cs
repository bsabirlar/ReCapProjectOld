using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryDal()
        {
            _cars = new List<Car>
            {

            new Car  {Id = 1, BrandId = 2, ColorId = 23, DailyPrice = 10002, Description = "Yellow car", ModelYear = 1999 },
            new Car { Id = 2, BrandId = 24, ColorId = 655, DailyPrice = 35000, Description = "blue car", ModelYear = 1991 },
            new Car { Id = 3, BrandId = 243, ColorId = 877, DailyPrice = 45666, Description = "sport car", ModelYear = 1995 },
            new Car { Id = 4, BrandId = 276, ColorId = 099, DailyPrice = 14344, Description = "slow car", ModelYear = 1990 }
            };
        }
            

        
        public void Add(Car car)
        {
            _cars.Add(car);
        }

       

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> Get(Expression<Func<Car, bool>> filter = null)
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

        public List<Car> GetById(int BrandId)
        {
            return _cars.Where(p => p.BrandId == BrandId).ToList();
        }

       
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
