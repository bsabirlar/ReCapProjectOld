using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarReCapDbContext>, ICarDal
    {
        public void Add(Car entity)
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {

                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();

            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.BrandId
                             join b in context.Colors
                             on p.ColorId equals b.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = c.BrandName,
                                 CarName = p.CarName,
                                 Id = p.Id,
                                 DailyPrice = p.DailyPrice
                             };
                return result.ToList();
            }
        }

        public void Update(Car entity)
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
